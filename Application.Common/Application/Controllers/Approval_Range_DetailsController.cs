using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Common.Application.Controllers
{
    [ApiController]
    [Route("/api/v1/ccvp_apwb_nego/Approval_Range_Details")]
    public class Approval_Range_DetailsController: ControllerBase
    {
        private readonly IApproval_Range_DetailsService _service;

        public Approval_Range_DetailsController(
            IApproval_Range_DetailsService approval_Range_DetailsService
            )
        {
            _service = approval_Range_DetailsService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseService<Approval_Range_Details>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] Approval_Range_Details approval_range_details)
        {
            Validator.Validate<Approval_Range_Details>(approval_range_details);
            var result = await _service.Create(approval_range_details);
            return Ok(new ResponseService<Approval_Range_Details>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResponseService<Approval_Range_Details>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(new ResponseService<Approval_Range_Details>
            {
                Status = true,
                Data = result
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<Approval_Range_Details>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.List();
            return Ok(new ResponseService<IEnumerable<Approval_Range_Details>>
            {
                Status = true,
                Data = result
            });
        }
    }
}

