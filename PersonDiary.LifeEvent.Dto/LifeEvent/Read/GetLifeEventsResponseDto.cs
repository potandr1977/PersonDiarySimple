using System.Collections.Generic;
using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventsResponseDto : Response<GetLifeEventsResponseDto>
    {
        public List<LifeEventDto> LifeEvents { get; set; }
    }
}
