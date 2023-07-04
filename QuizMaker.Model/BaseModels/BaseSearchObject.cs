namespace QuizMaker.Model.BaseModels
{
    public class BaseSearchObject
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public BaseSearchObject()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}
