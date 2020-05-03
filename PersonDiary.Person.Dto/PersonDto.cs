using System.Collections.Generic;

namespace PersonDiary.Person.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public List<LifeEventDto> LifeEvents { get; set; }
        
        public bool HasFile { get; set; }

    }
}
