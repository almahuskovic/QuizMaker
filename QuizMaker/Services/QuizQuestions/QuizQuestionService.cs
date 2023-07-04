using AutoMapper;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Entities;
using QuizMaker.Model.Requests.QuizQuestions;
using QuizMaker.Services.BaseCRUD;
using System.Collections.Generic;
using System.Linq;

namespace QuizMaker.Services.QuizQuestions
{
    public class QuizQuestionService : BaseCRUDService<QuizQuestionDto, QuizQuestion, QuizQuestionSearchRequest, QuizQuestionUpsertRequest, QuizQuestionUpsertRequest>, IQuizQuestionService
    {
        public QuizQuestionService(Context context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IEnumerable<QuizQuestionDto> Get(QuizQuestionSearchRequest search = null)
        {
            var entity = Context.Set<QuizQuestion>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Question))
            {
                entity = entity.Where(x => x.Question.ToLower().Contains(search.Question.ToLower()));
            }

            var list = entity.Take(search.PageSize.Value).Skip((search.Page.Value - 1) * search.PageSize.Value).ToList();
            var mappedList = _mapper.Map<List<QuizQuestionDto>>(list);

            return mappedList;
        }
    }
}
