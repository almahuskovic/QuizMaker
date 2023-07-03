using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizMaker.Services.BaseRead
{
    public class BaseReadService<T, TDb, TSearch> : IBaseReadService<T, TSearch> where T : class where TDb : class where TSearch : class
    {
        public Context Context { get; set; }
        protected readonly IMapper _mapper;
        public BaseReadService(Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch search = null, int page = 1, int pageSize = 10)
        {
            var entity = Context.Set<TDb>();

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
