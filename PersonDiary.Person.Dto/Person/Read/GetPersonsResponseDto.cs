using System.Collections.Generic;
using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class GetPersonsResponseDto : Response<GetPersonsResponseDto>
    {
        public List<PersonDto> Persons { get; set; }
        
        public int Count { get; set; }
    }
}
