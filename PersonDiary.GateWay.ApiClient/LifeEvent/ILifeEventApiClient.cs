
using PersonDiary.GateWay.Dto;
using System.Threading.Tasks;

namespace PersonDiary.GateWay.ApiClient
{
    public interface ILifeEventApiClient
    {
        Task<GetLifeEventsResponseDto> GetLifeEvents(GetLifeEventsRequestDto reqeust);

        Task<GetLifeEventResponseDto> GetLifeEvent(int id);

        Task<GetLifeEventsResponseDto> GetLifeEventsByPersonId(int personId);

        Task SaveOrUpdate(UpdateLifeEventRequestDto UpdateLifeEventRequest);

        Task Delete(int id);
    }
}
