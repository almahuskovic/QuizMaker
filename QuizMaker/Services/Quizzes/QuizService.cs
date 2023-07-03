using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Entities;
using QuizMaker.Model.Requests.Quizzes;
using QuizMaker.Services.BaseCRUD;
using System.Collections.Generic;
using System.Linq;

namespace QuizMaker.Services.Quizzes
{
    public class QuizService : BaseCRUDService<QuizDto, Quiz, QuizSearchRequest, QuizUpsertRequest, QuizUpsertRequest>, IQuizService
    {
        public QuizService(Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public override IEnumerable<QuizDto> Get(QuizSearchRequest search = null, int page = 1, int pageSize = 10)
        {
            var entity = Context.Set<Quiz>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var list = entity.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var mappedList = _mapper.Map<List<QuizDto>>(list);

            return mappedList;
        }
        public override QuizDto Insert(QuizUpsertRequest request)
        {
            var entity = Context.Set<Quiz>().AsQueryable();
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return null;// HttpStatusCode.BadRequest;
            }
            if (entity.Any(x => x.Name == request.Name))
            {
                return null;//STATUS KOD
            }

            var mappedEntity = _mapper.Map<Quiz>(request);
            Context.Add(mappedEntity);

            Context.SaveChanges();//probati da ide samo na kraju

            foreach (var question in request.QuizQuestions)
            {
                var questionId = question.Id;
                if (!question.IsRecycled)
                {
                    var addQuestion = new QuizQuestion() { Question = question.Question, Answear = question.Answear };
                    Context.Add(addQuestion);
                    questionId = addQuestion.Id;
                }

                var quizzesQuestions = new Model.Entities.QuizzesQuestions() { QuizId = mappedEntity.Id, QuizQuestionId = questionId };
                Context.Add(quizzesQuestions);
            }

            Context.SaveChanges();


            return _mapper.Map<QuizDto>(mappedEntity);
        }
    }
}
