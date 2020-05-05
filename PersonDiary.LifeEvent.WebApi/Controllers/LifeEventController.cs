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
        public async Task<GetLifeEventsResponseDto> GetLifeEventByPersonId([FromQuery] GetLifeEventsByPersonIdRequest request)
        {
            return await lifeEventService.GetItemsByPersonIdAsync(request);
        }

        [HttpGet("{id}")]
        public async Task<GetLifeEventResponseDto> Get(int id)
        {
            return await lifeEventService.GetItemAsync(new GetLifeEventRequestDto() { Id = id });
        }
        
        [HttpPost]
        public async Task<UpdateLifeEventResponseDto> Post([FromBody]  UpdateLifeEventRequestDto request)
        {
            return await lifeEventService.CreateAsync(request);
        }

        [HttpPut]
        public async Task<UpdateLifeEventResponseDto> Put([FromBody] UpdateLifeEventRequestDto request)
        {
            return await lifeEventService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteLifeEventResponseDto> Delete(int id)
        {
            return await lifeEventService.DeleteAsync(new DeleteLifeEventRequestDto() { Id = id });
        }

        [HttpPost]
        [Route("GetLifeEventsByPersonId")]
        public Task PersonCreatedAsync([FromBody]  UpdateLifeEventRequestDto request)
        {
            return lifeEventService.PersonCreatedAsync(request);
        }
    }
}
