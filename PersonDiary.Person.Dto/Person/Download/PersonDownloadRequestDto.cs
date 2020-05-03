using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class PersonDownloadRequestDto : Request
    {
        public int PersonId { get; set; }
    }
}
