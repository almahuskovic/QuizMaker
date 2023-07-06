using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using QuizMaker.Model.BaseModels;
using QuizMaker.Services.BaseRead;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace QuizMaker.Services.BaseCRUD
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> :
        BaseReadService<T, TDb, TSearch>,
        IBaseCRUDService<T, TSearch, TInsert, TUpdate>
        where T : class where TDb : BaseClass where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public async virtual Task<T> Insert(TInsert request)
        {
            var set = Context.Set<TDb>();
            TDb entity = _mapper.Map<TDb>(request);
            set.Add(entity);
            await Context.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }

        public async virtual Task<T> Update(Guid id, TUpdate request)
        {
            var set = Context.Set<TDb>();
            var entity = set.Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _mapper.Map(request, entity);
            await Context.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }
        
        public async virtual Task<T> Delete(Guid id, bool hardDelete = false)
        {
            var entity = Context.Set<TDb>().Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            if (hardDelete)
            {
                Context.Set<TDb>().Remove(entity);
            }
            else
            {
                entity.IsDeleted = true;
            }
            await Context.SaveChangesAsync();

            var mappedEntity = _mapper.Map<T>(entity);
            return mappedEntity;
        }
    }
}
