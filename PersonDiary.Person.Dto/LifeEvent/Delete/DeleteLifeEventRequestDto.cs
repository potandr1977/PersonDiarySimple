using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class DeleteLifeEventRequestDto : Request
    {
        public int Id { get; set; }
    }
}
