using PersonDiary.Person.Dto;
using System.Threading.Tasks;

namespace PersonDiary.Person.ApiClient
{
    public interface ILifeEventApiClient
    {
        Task<GetLifeEventResponseDto> GetLifeEvent(int id);

        Task<GetLifeEventsResponseDto> GetLifeEventsByPersonId(int personId);

        Task SaveOrUpdate(UpdateLifeEventRequestDto UpdateLifeEventRequest);

        Task Delete(int id);
    }
}
