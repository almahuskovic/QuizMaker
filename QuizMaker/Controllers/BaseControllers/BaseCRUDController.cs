using Microsoft.AspNetCore.Mvc;
using QuizMaker.Services.BaseCRUD;
using System;
using System.Threading.Tasks;

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
        public async Task<T> Insert([FromBody] TInsert request)
        {
            return await _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public async Task<T> Update(Guid id, [FromBody] TUpdate request)
        {
            return await _crudService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<T> Delete(Guid id)
        {
            return await _crudService.Delete(id);
        }
    }
}
