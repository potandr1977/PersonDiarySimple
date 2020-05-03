using System.Collections.Generic;
using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.Dto
{
    public class GetLifeEventsResponseDto : Response<GetLifeEventsResponseDto>
    {
        public List<LifeEventDto> LifeEvents { get; set; }
    }
}
