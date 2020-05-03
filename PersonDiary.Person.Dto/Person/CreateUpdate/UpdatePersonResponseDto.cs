using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.Person.Dto
{
    public class UpdatePersonResponseDto : Response<UpdatePersonResponseDto>
    {
        public PersonDto Person { get; set; }
    }
}
