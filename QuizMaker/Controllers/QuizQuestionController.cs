using Microsoft.AspNetCore.Mvc;
using QuizMaker.Controllers.BaseControllers;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.QuizQuestions;
using QuizMaker.Services.QuizQuestions;

namespace QuizMaker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizQuestionController : BaseCRUDController<QuizQuestionDto, QuizQuestionSearchRequest, QuizQuestionUpsertRequest, QuizQuestionUpsertRequest>
    {
        public QuizQuestionController(IQuizQuestionService quizQuestionService) : base(quizQuestionService)
        {

        }
    }
}
