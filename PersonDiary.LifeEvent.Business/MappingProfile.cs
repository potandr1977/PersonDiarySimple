using AutoMapper;
using PersonDiary.LifeEvent.Dto;

namespace PersonDiary.LifeEvent.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LifeEventDto, LifeEvent.Models.LifeEvent>();

            CreateMap<LifeEvent.Models.LifeEvent, LifeEventDto>();

        }
    }
}
