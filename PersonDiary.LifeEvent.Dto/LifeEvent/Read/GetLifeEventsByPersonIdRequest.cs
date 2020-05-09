using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventsByPersonIdRequest : Request
    {
        public int personId { get; set; }
    }
}
