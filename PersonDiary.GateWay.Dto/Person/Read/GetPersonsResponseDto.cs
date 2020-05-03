using System.Collections.Generic;
using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;

namespace PersonDiary.GateWay.Dto
{
    public class GetPersonsResponseDto : Response<GetPersonsResponseDto>
    {
        public List<PersonDto> Persons { get; set; }
        
        public int Count { get; set; }
    }
}
