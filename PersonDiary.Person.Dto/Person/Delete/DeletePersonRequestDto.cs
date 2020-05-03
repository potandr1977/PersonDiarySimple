using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class DeletePersonRequestDto : Request
    {
        public int Id { get; set; }
    }
}
