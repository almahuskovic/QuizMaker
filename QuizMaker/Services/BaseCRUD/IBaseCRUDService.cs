using QuizMaker.Services.BaseRead;
using System;

namespace QuizMaker.Services.BaseCRUD
{
    public interface IBaseCRUDService<T, TSearch, TInsert, TUpdate> : IBaseReadService<T, TSearch>
      where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        T Insert(TInsert request);
        T Update(Guid id, TUpdate request);
        T Delete(Guid id);
    }
}
