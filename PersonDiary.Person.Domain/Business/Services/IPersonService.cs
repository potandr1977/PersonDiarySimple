using System.Threading.Tasks;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.Domain.Business.Services
{
    public interface IPersonService
    {
        Task<GetPersonsResponseDto> GetItemsAsync(GetPersonsRequestDto request);

        Task<GetPersonResponseDto> GetItemAsync(GetPersonRequestDto request);

        Task<UpdatePersonResponseDto> CreateAsync(UpdatePersonRequestDto request);

        Task<UpdatePersonResponseDto> UpdateAsync(UpdatePersonRequestDto request);

        Task<DeletePersonResponseDto> DeleteAsync(DeletePersonRequestDto request);

        Task<PersonUploadResponseDto> UploadAsync(PersonUploadRequestDto request);

        Task<byte[]> DownloadAsync(GetPersonRequestDto request);

        Task<DeletePersonResponseDto> DeleteBiographyAsync(DeletePersonRequestDto request);
    }
}