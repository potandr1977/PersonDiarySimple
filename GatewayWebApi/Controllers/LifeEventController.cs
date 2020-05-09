using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.GateWay.ApiClient;
using PersonDiary.GateWay.Dto;

namespace GatewayWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        private readonly ILifeEventApiClient lifeEventApiClient;

        public LifeEventController(ILifeEventApiClient lifeEventApiClient)
        {
            this.lifeEventApiClient = lifeEventApiClient;
        }

        [HttpGet]
        public Task<GetLifeEventsResponseDto> Get([FromQuery] GetLifeEventsRequestDto request)
        {
            return lifeEventApiClient.GetLifeEvents(request);
        }
    }
}