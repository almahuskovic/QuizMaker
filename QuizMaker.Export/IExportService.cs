namespace QuizMaker.Export
{
    public interface IExportService<T> where T : class
    {
        string Format { get; }
        void Save(List<T> data);
    }
}
