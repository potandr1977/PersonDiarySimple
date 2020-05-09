
using PersonDiary.Infrastructure.Dto;

namespace PersonDiary.LifeEvent.Dto
{
    public class GetPersonResponseDto : Response<GetPersonResponseDto>
    {
        public PersonDto Person { get; set; }
    }
}
