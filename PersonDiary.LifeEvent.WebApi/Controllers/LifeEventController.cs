using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PersonDiary.LifeEvent.Domain.Business.Services;
using PersonDiary.LifeEvent.Dto;

namespace PersonDiary.LifeEvent.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LifeEventController : ControllerBase
    {
        private readonly ILifeEventService lifeEventService;

        public LifeEventController(ILifeEventService lifeEventService)
        {
            this.lifeEventService = lifeEventService;
        }

        [HttpGet]
        public async Task<GetLifeEventsResponseDto> Get([FromQuery] GetLifeEventsRequestDto request)
        {
            var resp = await lifeEventService.GetItemsAsync(request);

            return resp;
        }

        [HttpGet]
        [Route("GetLifeEventsByPersonId")]
        public Task<GetLifeEventsResponseDto> GetLifeEventByPersonId([FromQuery] GetLifeEventsByPersonIdRequest request)
        {
            return lifeEventService.GetItemsByPersonIdAsync(request);
        }

        [HttpGet("{id}")]
        public Task<GetLifeEventResponseDto> Get(int id)
        {
            return lifeEventService.GetItemAsync(new GetLifeEventRequestDto() { Id = id });
        }

        [HttpPost]
        public Task<UpdateLifeEventResponseDto> Post([FromBody]  UpdateLifeEventRequestDto request)
        {
            return lifeEventService.CreateAsync(request);
        }

        [HttpPut]
        public Task<UpdateLifeEventResponseDto> Put([FromBody] UpdateLifeEventRequestDto request)
        {
            return lifeEventService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public Task<DeleteLifeEventResponseDto> Delete(int id)
        {
            return lifeEventService.DeleteAsync(new DeleteLifeEventRequestDto() { Id = id });
        }

        [HttpGet]
        [Route("PersonCreated")]
        public Task PersonCreatedAsync([FromQuery] PersonCreateDto request)
        {
            return lifeEventService.PersonCreatedAsync(request);
        }
    }
}
