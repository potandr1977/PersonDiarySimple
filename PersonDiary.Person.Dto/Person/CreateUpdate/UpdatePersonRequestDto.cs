using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class UpdatePersonRequestDto : Request
    {
        public PersonDto Person { get; set; }
    }
}
