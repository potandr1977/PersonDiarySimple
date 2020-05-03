using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class UpdatePersonRequestDto : Request
    {
        public PersonDto Person { get; set; }
    }
}
