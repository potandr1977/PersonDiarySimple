using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class GetLifeEventResponseDto : Response<GetLifeEventResponseDto>
    {
        public LifeEventDto LifeEvent { get; set; }
    }
}
