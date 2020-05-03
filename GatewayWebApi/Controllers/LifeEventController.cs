using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        /*
        [HttpGet]
        public async Task<GetLifeEventListResponse> Get([FromQuery] GetLifeEventListRequest request)
        {
            var resp = await lifeEventService.GetItemsAsync(request);

            return resp;
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

        [HttpPut("{id}")]
        public async Task<UpdateLifeEventResponse> Put(int id, [FromBody] UpdateLifeEventRequest request)
        {
            return await lifeEventService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteLifeEventResponse> Delete(int id)
        {
            return await lifeEventService.DeleteAsync(new DeleteLifeEventRequest() { Id = id });
        }
        */
    }
}