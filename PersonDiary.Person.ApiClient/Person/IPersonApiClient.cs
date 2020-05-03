using PersonDiary.Person.Dto;
using System.Threading.Tasks;

namespace PersonDiary.Person.ApiClient
{
    public interface IPersonApiClient
    {
        Task<GetPersonResponseDto> GetPersonAsync(GetPersonRequestDto getPersonRequestDto);

        Task<GetPersonsResponseDto> GetPersonsAsync(GetPersonsRequestDto getPersonsRequestDto);

        Task SaveOrUpdatePersonAsync(UpdatePersonRequestDto updatePersonRequestDto);

        Task DeletePersonAsync(DeletePersonRequestDto deletePersonRequestDto);
        
        Task LifeEventCreatedAsync(UpdateLifeEventRequestDto lifeEventCreateDto);
    }
}