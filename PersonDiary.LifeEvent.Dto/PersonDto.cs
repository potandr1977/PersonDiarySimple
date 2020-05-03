using System.Collections.Generic;

namespace PersonDiary.LifeEvent.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public bool HasFile { get; set; }
    }
}
