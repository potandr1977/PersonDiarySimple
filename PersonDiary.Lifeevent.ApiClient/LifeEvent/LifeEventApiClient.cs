using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using System.Threading.Tasks;
using PersonDiary.LifeEvent.Dto;

namespace PersonDiary.LifeEvent.ApiClient
{
    public class LifeEventApiClient : BaseApiClient, ILifeEventApiClient
    {
        public LifeEventApiClient
        (
            IHttpRequestExecutor httpRequestExecutor,
            IUriCreator uriCreator,
            IResponseParser responseParser
        )
            : base(httpRequestExecutor, uriCreator, responseParser)
        {
        }
        protected override string GetApiEndpoint()
        {
            return Settings.LifeEventMicroServiceUrl;
        }
        public Task<GetLifeEventResponseDto> GetLifeEvent(int id)
        {
            return GetAsync<GetLifeEventResponseDto>($"api/LifeEvent/", id);
        }

        public Task<GetLifeEventsResponseDto> GetLifeEventsByPersonId(int personId)
        {
            return GetAsync<GetLifeEventsResponseDto>($"/api/lifeevent/GetLifeEventsByPersonId?personId={personId}");
        }

        public Task SaveOrUpdate(UpdateLifeEventRequestDto updateLifeEventRequest)
        {
            return PutAsync("api/lifeevent/", updateLifeEventRequest);
        }

        public Task Delete(int id)
        {
            return DeleteAsync($"api/person/", id);
        }

        public Task PersonCreatedAsync(PersonCreateDto personCreateDto)
        {
            return PostAsync("api/lifeevent/PersonCreatedAsync", personCreateDto);
        }
    }
}
