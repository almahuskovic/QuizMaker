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
        public virtual async Task<ActionResult<T>> Insert([FromBody] TInsert request)
        {
            try
            {
                return await _crudService.Insert(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<T>> Update(Guid id, [FromBody] TUpdate request)
        {
            try
            {
                return await _crudService.Update(id, request);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Not found")
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex);
                }
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<T>> Delete(Guid id)
        {
            try
            {
                return await _crudService.Delete(id);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Not found")
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex);
                }
            }
        }
    }
}
