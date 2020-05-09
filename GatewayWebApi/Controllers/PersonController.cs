using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.GateWay.ApiClient;
using PersonDiary.GateWay.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GatewayWebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonApiClient personApiClient;

        public PersonController(IPersonApiClient personApiClient)
        {
            this.personApiClient = personApiClient;
        }
        [HttpGet]
        public Task<GetPersonsResponseDto> Get([FromQuery] GetPersonsRequestDto request)
        {
            return personApiClient.GetPersonsAsync(request);
        }

        [HttpGet("{id}")]
        public Task<GetPersonResponseDto> Get(int id)
        {
            return personApiClient.GetPersonAsync(new GetPersonRequestDto { Id = id });
        }
    }
}
