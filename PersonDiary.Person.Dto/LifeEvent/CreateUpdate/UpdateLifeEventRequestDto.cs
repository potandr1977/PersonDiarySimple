using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.Dto
{
    public class UpdateLifeEventRequestDto : Request
    {
        public LifeEventDto LifeEvent { get; set; }
    }
}
