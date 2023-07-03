using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.QuizQuestions;
using QuizMaker.Services.BaseCRUD;

namespace QuizMaker.Services.QuizQuestions
{
    public interface IQuizQuestionService : IBaseCRUDService<QuizQuestionDto, QuizQuestionSearchRequest, QuizQuestionUpsertRequest, QuizQuestionUpsertRequest>
    {
    }
}
