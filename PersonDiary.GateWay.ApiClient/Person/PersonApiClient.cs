using System.Threading.Tasks;
using PersonDiary.GateWay.Dto;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.ApiClient
{
    public class PersonApiClient : BaseApiClient, IPersonApiClient
    {
        public PersonApiClient
        (
            IHttpRequestExecutor httpRequestExecutor,
            IUriCreator uriCreator,
            IResponseParser responseParser
        )
            : base(httpRequestExecutor, uriCreator, responseParser)
        {            
        }
        
        protected  override string GetApiEndpoint() 
        {
            return Settings.PersonMicroServiceUrl;
        }
        
        public Task<GetPersonResponseDto> GetPersonAsync(GetPersonRequestDto getPersonRequestDto)
        {
            return GetAsync<GetPersonResponseDto>($"api/Person/", getPersonRequestDto);
        }

        public Task<GetPersonsResponseDto> GetPersonsAsync(GetPersonsRequestDto getPersonsRequestDto)
        {
           return GetAsync<GetPersonsResponseDto>(
               $"/api/person/?json={{pageNo: {getPersonsRequestDto.PageNo} ,pageSize:{getPersonsRequestDto.PageSize}}}");
        }
        
        public Task SaveOrUpdatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto)
        {
            return PutAsync($"api/person/",updatePersonRequestDto);
        }

        public Task DeletePersonAsync(DeletePersonRequestDto deletePersonRequestDto)
        {
            return DeleteAsync($"api/person/",new { id = deletePersonRequestDto.Id });
        }

        public Task LifeEventCreatedAsync(UpdateLifeEventRequestDto lifeEventCreateDto)
        {
            return PostAsync($"api/person/lifeeventcreated", lifeEventCreateDto);
        }
    }
}