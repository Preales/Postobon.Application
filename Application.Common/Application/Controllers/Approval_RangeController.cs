using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Common.Application.Controllers
{
    [ApiController]
    [Route("/api/v1/ccvp_apwb_nego/Approval_Range")]
    public class Approval_RangeController : ControllerBase
    {
        private readonly IApproval_RangeService _service;

        public Approval_RangeController(
            IApproval_RangeService approval_RangeService
            )
        {
            _service = approval_RangeService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseService<Approval_Range>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] Approval_Range approval_range)
        {
            Validator.Validate<Approval_Range>(approval_range);
            var result = await _service.Create(approval_range);
            return Ok(new ResponseService<Approval_Range>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResponseService<Approval_Range>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(new ResponseService<Approval_Range>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<Approval_Range>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.List();
            return Ok(new ResponseService<IEnumerable<Approval_Range>>
            {
                Status = true,
                Data = result
            });
        }
    }
}
