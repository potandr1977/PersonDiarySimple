using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class GetLifeEventRequestDto : Request
    {
        public int Id { get; set; }
    }
}
