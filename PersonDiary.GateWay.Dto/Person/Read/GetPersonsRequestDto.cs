using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class GetPersonsRequestDto : Request
    {
        public int PageNo { get; set; }
        
        public int PageSize { get; set; }
    }
}
