using Microsoft.AspNetCore.Mvc;
using QuizMaker.Controllers.BaseControllers;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.Quizzes;
using QuizMaker.Services.Quizzes;

namespace QuizMaker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : BaseCRUDController<QuizDto, QuizSearchRequest, QuizUpsertRequest, QuizUpsertRequest>
    {
        public QuizController(IQuizService quizService) : base(quizService)
        {

        }
    }
}
