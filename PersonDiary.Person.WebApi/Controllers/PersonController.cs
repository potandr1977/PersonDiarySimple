using Microsoft.AspNetCore.Mvc;
using PersonDiary.Person.Domain.Business.Services;
using PersonDiary.Person.Dto;
using System.Threading.Tasks;

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
        public async Task<GetPersonsResponseDto> Get([FromQuery]GetPersonsRequestDto request)
        {
            return await personService.GetItemsAsync(request);
        }

        [HttpGet("{id}")]
        public async Task<GetPersonResponseDto> Get(int id)
        {
            return await personService.GetItemAsync(new GetPersonRequestDto() { Id = id, withLifeEvents = true });
        }

        [HttpPost]
        public async Task<UpdatePersonResponseDto> Post([FromBody]  UpdatePersonRequestDto request)
        {
            return await personService.CreateAsync(request);
        }

        [HttpPut("{id}")]
        public async Task<UpdatePersonResponseDto> Put(int id, [FromBody] UpdatePersonRequestDto request)
        {
            return await personService.UpdateAsync(request);
        }
        
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponseDto> Delete(int id)
        {
            return await personService.DeleteAsync(new DeletePersonRequestDto() { Id = id });
        }
    }
}