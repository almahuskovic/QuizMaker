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
        public override IEnumerable<QuizzesQuestionsDto> Get(QuizzesQuestionsSearchRequest search = null, int page = 1, int pageSize = 10)
        {
            var entity = Context.Set<Model.Entities.QuizzesQuestions>().AsQueryable();

            if (search.QuestionId.HasValue)//TODO:provjera za search
            {
                entity = entity.Include(x => x.QuizQuestion);
            }
            if (search.QuizId.HasValue)
            {
                entity = entity.Include(x => x.Quiz);
            }

            var mappedList = _mapper.Map<List<QuizzesQuestionsDto>>(entity).ToList();

            return mappedList;
        }
    }
}
