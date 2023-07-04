using QuizMaker.Model.BaseModels;
using System;

namespace QuizMaker.Model.Requests.QuizzesQuestions
{
    public class QuizzesQuestionsSearchRequest : BaseSearchObject
    {
        public Guid? QuizId { get; set; }
        public Guid? QuestionId { get; set; }
    }
}
