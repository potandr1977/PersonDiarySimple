using PersonDiary.LifeEvent.Dto;
using System.Threading.Tasks;

namespace PersonDiary.LifeEvent.ApiClient
{
    public interface IPersonApiClient
    {
        Task<GetPersonResponseDto> GetPersonAsync(GetPersonRequestDto getPersonRequestDto);
    }
}