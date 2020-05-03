using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class DeleteLifeEventRequestDto : Request
    {
        public int Id { get; set; }
    }
}
