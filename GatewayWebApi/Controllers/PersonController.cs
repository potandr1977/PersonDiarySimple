using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GatewayWebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        /*
        [HttpGet]
        public async Task<GetPersonListResponse> Get([FromQuery]GetPersonListRequest request)
        {
            return await personService.GetItemsAsync(request);
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
        */
    }
}
