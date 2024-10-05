using Application.Common.Application.Controllers.Base;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Application.Controllers
{
    [Route("/api/v1/ccvp_apwb_nego/macrosegment")]
    public class MacrosegmentsController : BaseMasterController<Macrosegment, string, IMacrosegmentService>
    {
        private readonly IMacrosegmentService _iService;
        public MacrosegmentsController(
            IMacrosegmentService service
            ) : base(service)
        {
            _iService = service;
        }
    }
}