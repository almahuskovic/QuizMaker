using QuizMaker.Model.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace QuizMaker.Model.Entities
{
    public class QuizzesQuestions : BaseClass
    {
        [Required, ForeignKey(nameof(Quiz))]
        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        [Required, ForeignKey(nameof(QuizQuestion))]
        public Guid QuizQuestionId { get; set; }
        public virtual QuizQuestion QuizQuestion { get; set; }
    }
}
