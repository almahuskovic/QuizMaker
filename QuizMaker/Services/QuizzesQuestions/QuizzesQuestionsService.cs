using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuizMaker.Model.DTO;
using QuizMaker.Model.Requests.QuizzesQuestions;
using QuizMaker.Services.BaseCRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace QuizMaker.Services.QuizzesQuestions
{
    public class QuizzesQuestionsService : BaseCRUDService<QuizzesQuestionsDto, Model.Entities.QuizzesQuestions, QuizzesQuestionsSearchRequest, QuizzesQuestionsUpsertRequest, QuizzesQuestionsUpsertRequest>, IQuizzesQuestionsService
    {
        [ImportMany]
        public IEnumerable<Export.IExportService<string>> FormatExports;

        private CompositionContainer _container;

        private IConfiguration _configuration;
        public QuizzesQuestionsService(Context context, IMapper mapper, IConfiguration configuration) : base(context, mapper)
        {
            _configuration = configuration;
        }

        public override IEnumerable<QuizzesQuestionsDto> Get(QuizzesQuestionsSearchRequest search = null)
        {
            var entity = Context.Set<Model.Entities.QuizzesQuestions>().AsQueryable().Where(x => !x.IsDeleted);

            if (search.QuizId != Guid.Empty && Guid.TryParse(search.QuizId.ToString(),out Guid g))
            {
                entity = entity.Where(x => x.QuizId == search.QuizId);
                entity = entity.Include(x => x.Quiz).Include(x => x.QuizQuestion);
            }

            var mappedList = _mapper.Map<List<QuizzesQuestionsDto>>(entity).Take(search.PageSize.Value).Skip((search.Page.Value - 1) * search.PageSize.Value).ToList();

            return mappedList;
        }
        public void Export(Guid id, string extension)
        {
            var entity = Context.Set<Model.Entities.QuizzesQuestions>().AsQueryable().Where(x => !x.IsDeleted);

            entity = entity.Where(x => x.QuizId == id);
            entity = entity.Include(x => x.Quiz).Include(x => x.QuizQuestion);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            var listOfQuestions = _mapper.Map<List<string>>(entity.Select(x => x.QuizQuestion.Question)).ToList();

            var catalog = new AggregateCatalog();

            var pluginsDir = AppDomain.CurrentDomain.BaseDirectory;
            catalog.Catalogs.Add(new DirectoryCatalog(pluginsDir, "*.dll"));

            _container = new CompositionContainer(catalog);

            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
                throw;
            }

            var format = FormatExports.FirstOrDefault(x => x.Format == extension);

            if (format == null)
            {
                throw new Exception("Unsupported format");
            }

            format.Save(listOfQuestions);
        }

        public List<string> GetExportFormats()
        {
            return _configuration.GetSection("ExportFormats:Formats").Get<List<string>>();
        }
    }
}
