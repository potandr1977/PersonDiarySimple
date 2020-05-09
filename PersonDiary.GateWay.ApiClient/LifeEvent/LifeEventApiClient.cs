using PersonDiary.GateWay.Dto;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using System.Threading.Tasks;

namespace PersonDiary.GateWay.ApiClient
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
        public Task<GetLifeEventsResponseDto> GetLifeEvents(GetLifeEventsRequestDto request)
        {
            return GetAsync<GetLifeEventsResponseDto>($"/api/LifeEvent/", request);
        }

        public Task<GetLifeEventResponseDto> GetLifeEvent(int id)
        {
            return GetAsync<GetLifeEventResponseDto>($"/api/LifeEvent/", id);
        }

        public Task<GetLifeEventsResponseDto> GetLifeEventsByPersonId(int personId)
        {
            return GetAsync<GetLifeEventsResponseDto>($"/api/lifeevent/GetLifeEventsByPersonId?personId={personId}");
        }

        public Task SaveOrUpdate(UpdateLifeEventRequestDto updateLifeEventRequest)
        {
            return PutAsync("/api/lifeevent/", updateLifeEventRequest);
        }

        public Task Delete(int id)
        {
            return DeleteAsync($"/api/person/", id);
        }
    }
}
