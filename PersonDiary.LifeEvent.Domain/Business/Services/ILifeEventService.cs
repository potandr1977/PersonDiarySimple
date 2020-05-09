using System.Threading.Tasks;
using PersonDiary.LifeEvent.Dto;

namespace PersonDiary.LifeEvent.Domain.Business.Services
{
    public interface ILifeEventService
    {
        Task<GetLifeEventsResponseDto> GetItemsAsync(GetLifeEventsRequestDto request);

        Task<GetLifeEventsResponseDto> GetItemsByPersonIdAsync(GetLifeEventsByPersonIdRequest request);

        Task<GetLifeEventResponseDto> GetItemAsync(GetLifeEventRequestDto request);

        Task<UpdateLifeEventResponseDto> CreateAsync(UpdateLifeEventRequestDto request);
        
        Task<UpdateLifeEventResponseDto> UpdateAsync(UpdateLifeEventRequestDto request);
        
        Task<DeleteLifeEventResponseDto> DeleteAsync(DeleteLifeEventRequestDto request);

        Task PersonCreatedAsync(PersonCreateDto request);
    }
}