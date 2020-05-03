
using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class GetPersonResponseDto : Response<GetPersonResponseDto>
    {
        public PersonDto Person { get; set; }
    }
}
