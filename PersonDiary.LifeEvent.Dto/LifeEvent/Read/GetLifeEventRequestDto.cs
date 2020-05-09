using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventRequestDto : Request
    {
        public int Id { get; set; }
    }
}
