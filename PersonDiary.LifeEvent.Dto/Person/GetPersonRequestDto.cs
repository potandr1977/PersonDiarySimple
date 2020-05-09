using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetPersonRequestDto : Request
    {
        public int Id { get; set; }
        
        public bool withLifeEvents { get; set; }
    }
}
