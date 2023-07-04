using AutoMapper;
using QuizMaker.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizMaker.Services.BaseRead
{
    public class BaseReadService<T, TDb, TSearch> : IBaseReadService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        public Context Context { get; set; }
        protected readonly IMapper _mapper;
        public BaseReadService(Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = Context.Set<TDb>().AsQueryable();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = entity.ToList();
            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(Guid id)
        {
            var set = Context.Set<TDb>();
            var entity = set.Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}
