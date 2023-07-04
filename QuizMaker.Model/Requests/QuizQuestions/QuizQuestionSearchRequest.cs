using QuizMaker.Model.BaseModels;

namespace QuizMaker.Model.Requests.QuizQuestions
{
    public class QuizQuestionSearchRequest : BaseSearchObject
    {
        public string Question { get; set; }
    }
}
