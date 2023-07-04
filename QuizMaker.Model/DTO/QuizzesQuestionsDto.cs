using System;
using QuizMaker.Model.BaseModels;
using System.Collections.Generic;

namespace QuizMaker.Model.DTO
{
    public class QuizzesQuestionsDto : BaseClass
    {
        public Guid QuizId { get; set; }
        public Guid QuizQuestionId { get; set; }
        public QuizDto Quiz { get; set; }
        public QuizQuestionDto QuizQuestion { get; set; }
    }
}
