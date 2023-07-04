using QuizMaker.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Model.Requests.QuizzesQuestions
{
    public class QuizzesQuestionsUpsertRequest
    {
        public Guid QuizId { get; set; }
        public Guid QuizQuestionId { get; set; }
        public IEnumerable<QuizQuestion> QuizQuestions { get; set; }
        public IEnumerable<Quiz> Quizzes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
