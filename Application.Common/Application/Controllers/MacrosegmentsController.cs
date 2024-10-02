using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Common.Application.Controllers
{
    [ApiController]
    [Route("/api/v1/ccvp_apwb_nego/macrosegment")]
    public class MacrosegmentsController : ControllerBase
    {
        private readonly IMacrosegmentService _service;

        public MacrosegmentsController(
            IMacrosegmentService macrosegmentService
            )
        {
            _service = macrosegmentService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseService<Macrosegment>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] Macrosegment macrosegment)
        {
            Validator.Validate<Macrosegment>(macrosegment);
            var result = await _service.Create(macrosegment);
            return Ok(new ResponseService<Macrosegment>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResponseService<Macrosegment>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(new ResponseService<Macrosegment>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<Macrosegment>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.List();
            return Ok(new ResponseService<IEnumerable<Macrosegment>>
            {
                Status = true,
                Data = result
            });
        }
    }
}