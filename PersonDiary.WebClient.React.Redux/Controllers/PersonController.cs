using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonDiary.Business;
using PersonDiary.Dto.Person;
using PersonDiary.Domain;
using System.Threading.Tasks;
using PersonDiary.Domain.Business.Services;

namespace PersonDiary.React.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public async Task<GetPersonListResponse> Get(string json)
        {
            return await personService.GetItemsAsync(JsonConvert.DeserializeObject<GetPersonListRequest>(json));
        }

        [HttpGet("{id}")]
        public async Task<GetPersonResponse> Get(int id)
        {
            return await personService.GetItemAsync(new GetPersonRequest() { Id = id, withLifeEvents = true });
        }

        [HttpPost]
        public async Task<UpdatePersonResponse> Post([FromBody]  UpdatePersonRequest request)
        {
            return await personService.CreateAsync(request);
        }

        [HttpPut("{id}")]
        public async Task<UpdatePersonResponse> Put(int id, [FromBody] UpdatePersonRequest request)
        {
            return await personService.UpdateAsync(request);
        }
        
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete(int id)
        {
            return await personService.DeleteAsync(new DeletePersonRequest() { Id = id });
        }

    }
}