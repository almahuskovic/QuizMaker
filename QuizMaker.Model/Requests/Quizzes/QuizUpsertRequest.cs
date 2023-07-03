using QuizMaker.Model.DTO;
using System.Collections.Generic;

namespace QuizMaker.Model.Requests.Quizzes
{
    public class QuizUpsertRequest
    {
        public string Name { get; set; }
        public IEnumerable<QuizQuestionDto> QuizQuestions { get; set; }
    }
}
