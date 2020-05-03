using System;

namespace PersonDiary.LifeEvent.Models
{
    //Сущность события в жизни персоны
    public class LifeEvent
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime EventDate { get; set; }
        
        public int PersonId { get; set; }
    }
}
