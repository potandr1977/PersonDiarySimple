using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class GetLifeEventRequestDto : Request
    {
        public int Id { get; set; }
    }
}
