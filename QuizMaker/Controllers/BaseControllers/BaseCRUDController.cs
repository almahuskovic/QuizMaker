using Microsoft.AspNetCore.Mvc;
using QuizMaker.Services.BaseCRUD;
using System;

namespace QuizMaker.Controllers.BaseControllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch>
        where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly IBaseCRUDService<T, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(IBaseCRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public T Insert([FromBody] TInsert request)
        {
            return _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(Guid id, [FromBody] TUpdate request)
        {
            return _crudService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public T Delete(Guid id)
        {
            return _crudService.Delete(id);
        }
    }
}
