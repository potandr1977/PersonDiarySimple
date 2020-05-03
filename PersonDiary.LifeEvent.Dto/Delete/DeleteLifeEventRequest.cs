using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class DeleteLifeEventRequest : Request
    {
        public int Id { get; set; }
    }
}
