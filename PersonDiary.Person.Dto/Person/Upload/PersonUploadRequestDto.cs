using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class PersonUploadRequestDto : Request
    {
        public int PersonId { get; set; }
        
        public byte[] Biography { get; set; }

    }
}
