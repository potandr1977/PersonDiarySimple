using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventsRequestDto : Request
    {
        public int PageNo { get; set; }
        
        public int PageSize { get; set; }
    }
}
