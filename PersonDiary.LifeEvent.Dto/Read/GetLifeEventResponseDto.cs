using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventResponseDto : Response<GetLifeEventResponseDto>
    {
        public LifeEventDto LifeEvent { get; set; }
    }
}
