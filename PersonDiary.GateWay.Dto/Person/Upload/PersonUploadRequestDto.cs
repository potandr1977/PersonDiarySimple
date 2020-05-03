using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class PersonUploadRequestDto : Request
    {
        public int PersonId { get; set; }
        
        public byte[] Biography { get; set; }

    }
}
