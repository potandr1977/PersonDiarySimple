using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class UpdateLifeEventRequest : Request
    {
        public LifeEventDto LifeEvent { get; set; }
    }
}
