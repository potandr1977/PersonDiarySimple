using System.Threading.Tasks;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.LifeEvent.Dto;

namespace PersonDiary.LifeEvent.ApiClient
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
            return GetAsync<GetPersonResponseDto>($"/api/Person/", getPersonRequestDto);
        }
    }
}