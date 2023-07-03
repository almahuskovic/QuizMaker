using QuizMaker.Model.BaseModels;
using System;

namespace QuizMaker.Model.DTO
{
    public class QuizzesQuestionsDto : BaseClass
    {
        public Guid QuizId { get; set; }
        public Guid QuizQuestionId { get; set; }
    }
}
