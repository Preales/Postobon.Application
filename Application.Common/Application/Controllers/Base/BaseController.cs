using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Common.Application.Controllers.Base
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController<T, TId, TService> : ControllerBase
        where T : class
        where TService : IService<T, TId>
    {
        protected readonly TService _service;


        protected BaseController(TService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IResponseService), (int)HttpStatusCode.OK)]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            ///Validator.Validate(entity);
            var result = await _service.Create(entity);
            return Ok(new ResponseService<T>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IResponseService), (int)HttpStatusCode.OK)]
        public virtual async Task<IActionResult> Get(TId id)
        {
            var result = await _service.Get(id);
            return Ok(new ResponseService<T>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IResponseService), (int)HttpStatusCode.OK)]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _service.List();
            return Ok(new ResponseService<IEnumerable<T>>
            {
                Status = true,
                Data = result
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(IResponseService), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put([FromBody] T entity)
        {
            ///Validator.Validate(entity);
            var result = await _service.Update(entity);
            return Ok(new ResponseService<T>
            {
                Status = true,
                Data = result
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IResponseService), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(TId id)
        {
            var status = await _service.Delete(id);
            return Ok(new ResponseService<T>
            {
                Status = status
            });
        }

        [HttpDelete("logic/{id}")]
        [ProducesResponseType(typeof(IResponseService), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLogic(TId id)
        {
            var status = await _service.DeleteLogic(id);
            return Ok(new ResponseService<T>
            {
                Status = status
            });
        }
    }
}
