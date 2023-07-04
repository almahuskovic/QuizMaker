using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.QuizzesQuestions;
using QuizMaker.Services.BaseCRUD;
using System.Collections.Generic;
using System.Linq;

namespace QuizMaker.Services.QuizzesQuestions
{
    public class QuizzesQuestionsService : BaseCRUDService<QuizzesQuestionsDto, Model.Entities.QuizzesQuestions, QuizzesQuestionsSearchRequest, QuizzesQuestionsUpsertRequest, QuizzesQuestionsUpsertRequest>, IQuizzesQuestionsService
    {
        public QuizzesQuestionsService(Context context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IEnumerable<QuizzesQuestionsDto> Get(QuizzesQuestionsSearchRequest search = null)
        {
            var entity = Context.Set<Model.Entities.QuizzesQuestions>().AsQueryable().Where(x => !x.IsDeleted);

            if (search.QuestionId.HasValue)//TODO:provjera za search nez da li skloniti ovaj if ili ga malo updateati
            {
                entity = entity.Where(x => x.QuizQuestionId == search.QuestionId.Value);
                entity = entity.Include(x => x.QuizQuestion);
            }
            if (search.QuizId.HasValue)
            {
                entity = entity.Where(x => x.QuizId == search.QuizId.Value);
                entity = entity.Include(x => x.Quiz).Include(x => x.QuizQuestion);
            }

            var mappedList = _mapper.Map<List<QuizzesQuestionsDto>>(entity).Take(search.PageSize.Value).Skip((search.Page.Value - 1) * search.PageSize.Value).ToList();

            return mappedList;
        }
    }
}
