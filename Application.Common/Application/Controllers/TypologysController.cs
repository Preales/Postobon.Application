using Application.Common.Application.Controllers.Base;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Application.Controllers
{
    [Route("/api/v1/ccvp_apwb_nego/typology")]
    public class TypologysController : BaseMasterController<Typology, string, ITypologyService>
    {
        private readonly ITypologyService _iService;

        public TypologysController(
            ITypologyService service
            ) : base(service)
        {
            _iService = service;
        }
    }
}
