using System.Threading.Tasks;
using PersonDiary.LifeEvent.Dto;

namespace PersonDiary.LifeEvent.ApiClient
{
    public interface ILifeEventApiClient
    {
        Task<GetLifeEventResponseDto> GetLifeEvent(int id);

        Task<GetLifeEventsResponseDto> GetLifeEventsByPersonId(int personId);

        Task SaveOrUpdate(UpdateLifeEventRequestDto UpdateLifeEventRequest);

        Task Delete(int id);

        Task PersonCreatedAsync(PersonCreateDto personCreateDto);
    }
}
