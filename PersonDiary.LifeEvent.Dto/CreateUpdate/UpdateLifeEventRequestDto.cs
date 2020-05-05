using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class UpdateLifeEventRequestDto : Request
    {
        public LifeEventDto LifeEvent { get; set; }
    }
}
