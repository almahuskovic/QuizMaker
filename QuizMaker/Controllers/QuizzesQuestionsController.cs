using Microsoft.AspNetCore.Mvc;
using QuizMaker.Controllers.BaseControllers;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.QuizzesQuestions;
using QuizMaker.Services.QuizzesQuestions;

namespace QuizMaker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizzesQuestionsController : BaseCRUDController<QuizzesQuestionsDto, QuizzesQuestionsSearchRequest, QuizzesQuestionsUpsertRequest, QuizzesQuestionsUpsertRequest>
    {
        public QuizzesQuestionsController(IQuizzesQuestionsService quizzesQuestionsService) : base(quizzesQuestionsService)
        {

        }
    }
}
