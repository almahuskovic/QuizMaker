using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Entities;
using QuizMaker.Model.Requests.QuizQuestions;
using QuizMaker.Model.Requests.Quizzes;
using QuizMaker.Model.Requests.QuizzesQuestions;
using QuizMaker.Services.BaseCRUD;
using QuizMaker.Services.QuizQuestions;
using QuizMaker.Services.QuizzesQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizMaker.Services.Quizzes
{
    public class QuizService : BaseCRUDService<QuizDto, Quiz, QuizSearchRequest, QuizUpsertRequest, QuizUpsertRequest>, IQuizService
    {
        protected IQuizzesQuestionsService _quizzesQuestionsService;
        protected IQuizQuestionService _quizQuestionService;
        public QuizService(Context context,
            IMapper mapper,
            IQuizzesQuestionsService quizzesQuestionsService,
            IQuizQuestionService quizQuestionService) : base(context, mapper)
        {
            _quizzesQuestionsService = quizzesQuestionsService;
            _quizQuestionService = quizQuestionService;
        }

        public override IEnumerable<QuizDto> Get(QuizSearchRequest search = null)
        {
            var entity = Context.Set<Quiz>().AsQueryable().Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var list = entity.Take(search.PageSize.Value).Skip((search.Page.Value - 1) * search.PageSize.Value).ToList();
            var mappedList = _mapper.Map<List<QuizDto>>(list);

            return mappedList;
        }
        public async override Task<QuizDto> Insert(QuizUpsertRequest request)
        {
            var entity = Context.Set<Quiz>().AsQueryable();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new Exception("Bad request");
            }
            if (entity.Any(x => x.Name == request.Name))
            {
                throw new Exception("Already exists");
            }

            var mappedEntity = _mapper.Map<Quiz>(request);
            Context.Add(mappedEntity);

            foreach (var question in request.QuizQuestions)
            {
                var questionId = question.Id;
                if (!question.IsRecycled)
                {
                    questionId = (await _quizQuestionService.Insert(new QuizQuestionUpsertRequest() { Question = question.Question, Answer = question.Answer })).Id;
                }

                await _quizzesQuestionsService.Insert(new QuizzesQuestionsUpsertRequest()
                {
                    QuizId = mappedEntity.Id,
                    QuizQuestionId = questionId
                });
            }

            Context.SaveChanges();

            return _mapper.Map<QuizDto>(mappedEntity);
        }

        public async override Task<QuizDto> Update(Guid id, QuizUpsertRequest request)
        {
            var entity = Context.Set<Quiz>().Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            if (!entity.Name.Equals(request.Name))
            {
                entity.Name = request.Name;
                await Context.SaveChangesAsync();
            }

            if (request.QuizQuestions != null && request.QuizQuestions.Any())
            {
                var quizzesQuestions = Context.Set<Model.Entities.QuizzesQuestions>().AsQueryable();
                var quizQuestions = quizzesQuestions.Where(x => x.QuizId == id).Include(x => x.QuizQuestion).AsEnumerable();

                var addedQuestions = quizQuestions.Any() ?
                    request.QuizQuestions.Where(y => (y.IsRecycled && Guid.TryParse(y.Id.ToString(), out Guid g)) || y.Id == Guid.Empty) :
                    request.QuizQuestions;

                foreach (var question in addedQuestions)
                {
                    var qId = question.Id;
                    if (!question.IsRecycled)
                    {
                        var quizQuestion = await _quizQuestionService.Insert(new QuizQuestionUpsertRequest()
                        {
                            Question = question.Question,
                            Answer = question.Answer
                        });
                        qId = quizQuestion.Id;
                    }

                    await _quizzesQuestionsService.Insert(new QuizzesQuestionsUpsertRequest()
                    {
                        QuizId = id,
                        QuizQuestionId = qId
                    });
                }

                var updatedQuestions = request.QuizQuestions.Where(y => quizQuestions.Any(x => x.QuizQuestionId == y.Id && !x.IsDeleted
                    && (y.Question != x.QuizQuestion.Question || y.Answer != x.QuizQuestion.Answer)));

                foreach (var question in updatedQuestions)
                {
                    await _quizQuestionService.Update(question.Id, new QuizQuestionUpsertRequest()
                    {
                        Question = question.Question,
                        Answer = question.Answer
                    });
                }

                var deletedQuestions = request.QuizQuestions.Where(y => quizQuestions.Any(x => x.QuizQuestionId == y.Id && x.QuizQuestion.IsDeleted != y.IsDeleted));

                foreach (var question in deletedQuestions)
                {
                    if (!quizzesQuestions.Any(x => x.QuizQuestionId == question.Id && x.QuizId != id))
                    {
                        await _quizQuestionService.Delete(question.Id);
                    }
                    await _quizzesQuestionsService.Delete(quizQuestions.First(x => x.QuizQuestionId == question.Id).Id);
                }
            }

            return _mapper.Map<QuizDto>(entity);
        }

        public async override Task<QuizDto> Delete(Guid id, bool hardDelete = false)
        {
            var entity = Context.Set<Quiz>().Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            var quizzesQuestions = Context.Set<Model.Entities.QuizzesQuestions>().AsQueryable().Where(x => x.QuizId == id);

            if (hardDelete)
            {
                Context.Remove(entity);
                foreach (var item in quizzesQuestions)
                {
                    Context.Remove(item);
                }
            }
            else
            {
                entity.IsDeleted = true;
                foreach (var item in quizzesQuestions)
                {
                    item.IsDeleted = true;
                }
            }
            await Context.SaveChangesAsync();
            return _mapper.Map<QuizDto>(entity);
        }
    }
}
