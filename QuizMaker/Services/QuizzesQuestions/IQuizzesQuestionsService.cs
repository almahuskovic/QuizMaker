using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.Quizzes;
using QuizMaker.Model.Requests.QuizzesQuestions;
using QuizMaker.Services.BaseCRUD;

namespace QuizMaker.Services.QuizzesQuestions
{
    public interface IQuizzesQuestionsService : IBaseCRUDService<QuizzesQuestionsDto, QuizzesQuestionsSearchRequest, QuizzesQuestionsUpsertRequest, QuizzesQuestionsUpsertRequest>
    {
    }
}
