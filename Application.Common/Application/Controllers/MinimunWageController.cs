using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Common.Application.Controllers
{
    [ApiController]
    [Route("/api/v1/ccvp_apwb_nego/minimunwage")]
    public class MinimunWageController : ControllerBase
    {
        private readonly IMinimunWageService _service;

        public MinimunWageController(
            IMinimunWageService MinimunWageService
            )
        {
            _service = MinimunWageService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseService<MinimunWage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] MinimunWage minimunwage)
        {
            Validator.Validate<MinimunWage>(minimunwage);
            var result = await _service.Create(minimunwage);
            return Ok(new ResponseService<MinimunWage>
            {
                Status = true,
                Data = result
            });
        }

        [HttpPut("{id:int}")]
        //[Route("{id:int}")]
        [ProducesResponseType(typeof(ResponseService<MinimunWage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(int id, [FromBody] MinimunWage minimunwage)
        {
            Validator.Validate<MinimunWage>(minimunwage);
            var result = await _service.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            

            var resultUpdate = await _service.Update(minimunwage);

            return Ok(new ResponseService<MinimunWage>
            {
                Status = true,
                Data = resultUpdate
            });
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ResponseService<MinimunWage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {            
            var result = await _service.Get(id);
            if (result == null)
            {
                return NotFound();
            }
           
            var resultDelete = await _service.Delete(id);

            return Ok(new ResponseService<MinimunWage>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResponseService<MinimunWage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(new ResponseService<MinimunWage>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<MinimunWage>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.List();
            return Ok(new ResponseService<IEnumerable<MinimunWage>>
            {
                Status = true,
                Data = result
            });
        }
    }
}