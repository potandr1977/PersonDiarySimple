using System.Threading.Tasks;
using PersonDiary.LifeEvent.Dto;

namespace PersonDiary.LifeEvent.Domain.Business.Services
{
    public interface ILifeEventService
    {
        Task<GetLifeEventsResponse> GetItemsAsync(GetLifeEventsRequest request);

        Task<GetLifeEventsResponse> GetItemsByPersonIdAsync(GetLifeEventsByPersonIdRequest request);

        Task<GetLifeEventResponse> GetItemAsync(GetLifeEventRequest request);

        Task<UpdateLifeEventResponse> CreateAsync(UpdateLifeEventRequest request);
        
        Task<UpdateLifeEventResponse> UpdateAsync(UpdateLifeEventRequest request);
        
        Task<DeleteLifeEventResponse> DeleteAsync(DeleteLifeEventRequest request);
    }
}