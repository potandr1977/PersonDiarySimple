using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace PersonDiary.React.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        private readonly ILifeEventService lifeEventService;
        
        public LifeEventController(ILifeEventService lifeEventService,IPersonService personService)
        {
            this.lifeEventService = lifeEventService;
        }
        
        [HttpGet]
        public async Task<GetLifeEventListResponse> Get(string json)
        {
            var resp = await lifeEventService.GetItemsAsync(JsonConvert.DeserializeObject<GetLifeEventListRequest>(json));

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
    }
}
