using QuizMaker.Model.BaseModels;

namespace QuizMaker.Model.Requests.Quizzes
{
    public class QuizSearchRequest : BaseSearchObject
    {
        public string Name { get; set; }
    }
}
