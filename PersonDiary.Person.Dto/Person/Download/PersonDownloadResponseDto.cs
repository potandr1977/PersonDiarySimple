using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class PersonDownloadResponseDto : Response<PersonDownloadResponseDto>
    {
        public byte[] Biography { get; set; }
    }
}
