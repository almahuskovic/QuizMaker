using Microsoft.AspNetCore.Mvc;
using QuizMaker.Controllers.BaseControllers;
using QuizMaker.Model.DTO;
using QuizMaker.Services.QuizQuestions;

namespace QuizMaker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizQuestionController 
    {
        public QuizQuestionController(IQuizQuestionService quizQuestionService)
        {

        }
    }
}
