using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class PersonDownloadResponseDto : Response<PersonDownloadResponseDto>
    {
        public byte[] Biography { get; set; }
    }
}
