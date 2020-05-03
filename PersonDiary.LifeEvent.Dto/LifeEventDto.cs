using System;

namespace PersonDiary.LifeEvent.Dto
{
    //DTO события
    public class LifeEventDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime EventDate { get; set; }
        
        public string PersonFullName { get; set; }

    }
}
