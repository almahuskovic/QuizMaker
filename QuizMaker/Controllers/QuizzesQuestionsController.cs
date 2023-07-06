using Microsoft.AspNetCore.Mvc;
using QuizMaker.Controllers.BaseControllers;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.QuizzesQuestions;
using QuizMaker.Services.QuizzesQuestions;
using System;
using System.Collections.Generic;
using System.Net;

namespace QuizMaker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizzesQuestionsController : BaseCRUDController<QuizzesQuestionsDto, QuizzesQuestionsSearchRequest, QuizzesQuestionsUpsertRequest, QuizzesQuestionsUpsertRequest>
    {
        protected IQuizzesQuestionsService _quizzesQuestionsService;
        public QuizzesQuestionsController(IQuizzesQuestionsService quizzesQuestionsService) : base(quizzesQuestionsService)
        {
            _quizzesQuestionsService = quizzesQuestionsService;
        }

        [HttpGet("export/{id}/{extension}")]
        public IActionResult Export(Guid id, string extension)
        {
            try
            {
                _quizzesQuestionsService.Export(id, extension);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Not found")
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex);
                }
            }
        }

        [HttpGet("exportformats")]
        public List<string> GetExportFormats()
        {
            return _quizzesQuestionsService.GetExportFormats();
        }
    }
}
