using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Model.Requests.QuizQuestions
{
    public class QuizQuestionUpsertRequest
    {
        public string Question { get; set; }
        public string Answear { get; set; }
    }
}
