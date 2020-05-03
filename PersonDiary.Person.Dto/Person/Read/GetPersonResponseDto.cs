
using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class GetPersonResponseDto : Response<GetPersonResponseDto>
    {
        public PersonDto Person { get; set; }
    }
}
