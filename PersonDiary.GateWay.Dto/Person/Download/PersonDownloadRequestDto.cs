using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class PersonDownloadRequestDto : Request
    {
        public int PersonId { get; set; }
    }
}
