using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetLifeEventResponse : Response<GetLifeEventResponse>
    {
        public LifeEventDto LifeEvent { get; set; }
    }
}
