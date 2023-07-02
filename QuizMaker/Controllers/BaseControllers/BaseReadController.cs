using Microsoft.AspNetCore.Mvc;
using QuizMaker.Services.BaseRead;
using System;
using System.Collections.Generic;

namespace QuizMaker.Controllers.BaseControllers
{
    public class BaseReadController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        protected readonly IBaseReadService<T, TSearch> _service;

        public BaseReadController(IBaseReadService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery] TSearch search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public virtual T GetById(Guid id)
        {
            return _service.GetById(id);
        }
    }
}
