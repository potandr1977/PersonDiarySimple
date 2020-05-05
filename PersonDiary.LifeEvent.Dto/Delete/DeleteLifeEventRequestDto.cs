using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class DeleteLifeEventRequestDto : Request
    {
        public int Id { get; set; }
    }
}
