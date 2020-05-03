using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class UpdatePersonResponseDto : Response<UpdatePersonResponseDto>
    {
        public PersonDto Person { get; set; }
    }
}
