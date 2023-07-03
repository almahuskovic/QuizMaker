using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.Quizzes;
using QuizMaker.Services.BaseCRUD;

namespace QuizMaker.Services.Quizzes
{
    public interface IQuizService : IBaseCRUDService<QuizDto, QuizSearchRequest, QuizUpsertRequest, QuizUpsertRequest>
    {
    }
}
