using System;
using System.Collections.Generic;

namespace QuizMaker.Services.BaseRead
{
    public interface IBaseReadService<T, TSearch> where T : class where TSearch : class
    {
        public IEnumerable<T> Get(TSearch search = null);
        public T GetById(Guid id);//TODO:staviti string myb?
    }
}
