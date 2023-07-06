using System.ComponentModel.Composition;

namespace QuizMaker.Export
{
    [Export(typeof(IExportService<>))]
    public class CsvExporter<T> : IExportService<T> where T : class
    {
        public string Format => "CSV";

        public void Save(List<T> data)
        {
            var fileName = "QuizQuestions_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + "." + Format.ToLower();
            string downloadsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
            var filePath = downloadsFolderPath + fileName;

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var item in data)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
