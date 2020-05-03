using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventRequest : Request
    {
        public int Id { get; set; }
    }
}
