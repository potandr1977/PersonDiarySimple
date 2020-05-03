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
        public async Task<GetLifeEventsResponse> Get([FromQuery] GetLifeEventsRequest request)
        {
            var resp = await lifeEventService.GetItemsAsync(request);

            return resp;
        }

        [HttpGet]
        [Route("GetLifeEventsByPersonId")]
        public async Task<GetLifeEventsResponse> GetLifeEventByPersonId([FromQuery] GetLifeEventsByPersonIdRequest request)
        {
            return await lifeEventService.GetItemsByPersonIdAsync(request);
        }

        [HttpGet("{id}")]
        public async Task<GetLifeEventResponse> Get(int id)
        {
            return await lifeEventService.GetItemAsync(new GetLifeEventRequest() { Id = id });
        }
        
        [HttpPost]
        public async Task<UpdateLifeEventResponse> Post([FromBody]  UpdateLifeEventRequest request)
        {
            return await lifeEventService.CreateAsync(request);
        }

        [HttpPut]
        public async Task<UpdateLifeEventResponse> Put([FromBody] UpdateLifeEventRequest request)
        {
            return await lifeEventService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteLifeEventResponse> Delete(int id)
        {
            return await lifeEventService.DeleteAsync(new DeleteLifeEventRequest() { Id = id });
        }
    }
}
