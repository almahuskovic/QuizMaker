using QuizMaker.Model.BaseModels;
using System;

namespace QuizMaker.Model.DTO
{
    public class QuizQuestionDto : BaseClass
    {
        public string Question { get; set; }
        public string Answear { get; set; }
        public bool IsRecycled { get; set; }
    }
}
