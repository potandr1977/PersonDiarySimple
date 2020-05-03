using AutoMapper;
using PersonDiary.Person.Dto;

namespace PersonDiary.Person.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDto, Person.Models.Person>();
            
            CreateMap<Person.Models.Person, PersonDto>()
                .ForMember(
                    dist => dist.HasFile, 
                    opt => 
                        opt.MapFrom(src => src.Biography != null));
        }
    }
}
