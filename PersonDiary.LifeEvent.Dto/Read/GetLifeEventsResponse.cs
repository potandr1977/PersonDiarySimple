using System.Collections.Generic;
using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventsResponse : Response<GetLifeEventsResponse>
    {
        public List<LifeEventDto> LifeEvents { get; set; }
    }
}
