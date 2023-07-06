using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.QuizzesQuestions;
using QuizMaker.Services.BaseCRUD;
using System;
using System.Collections.Generic;

namespace QuizMaker.Services.QuizzesQuestions
{
    public interface IQuizzesQuestionsService : IBaseCRUDService<QuizzesQuestionsDto, QuizzesQuestionsSearchRequest, QuizzesQuestionsUpsertRequest, QuizzesQuestionsUpsertRequest>
    {
        public void Export(Guid id, string extension);
        public List<string> GetExportFormats();
    }
}
