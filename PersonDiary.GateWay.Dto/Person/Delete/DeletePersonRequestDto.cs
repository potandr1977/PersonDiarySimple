using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class DeletePersonRequestDto : Request
    {
        public int Id { get; set; }
    }
}
