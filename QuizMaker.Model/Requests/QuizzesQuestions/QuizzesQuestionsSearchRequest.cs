using System;

namespace QuizMaker.Model.Requests.QuizzesQuestions
{
    public class QuizzesQuestionsSearchRequest
    {
        public Guid? QuizId { get; set; }
        public Guid? QuestionId { get; set; }
    }
}
