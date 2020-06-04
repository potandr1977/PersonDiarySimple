using System;
using Microsoft.EntityFrameworkCore;

namespace PersonDiary.Contexts
{
    //Класс контекста базы данных
    public class SqlContext : DbContext
    {
        public DbSet<LifeEvent.Models.LifeEvent> LifeEvents { get; set; }

        public SqlContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=1;Server=127.0.0.1;Port=5433;Database=Lifeevent;Integrated Security=true;Pooling=true;"
                );
        }
        /// <summary>
        /// Устанавливаем правила удаления событий персоны с помощью Fluent API и набиваем БД тестовыми данными 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LifeEvent.Models.LifeEvent>().HasData(
                new LifeEvent.Models.LifeEvent[]
                {
                            new LifeEvent.Models.LifeEvent() { Id =1, Name="born", EventDate = new DateTime(1958,08,29), PersonId  =1},
                            new LifeEvent.Models.LifeEvent() { Id =2, Name="die", EventDate = new DateTime(2009,06,25), PersonId  =1 },
                            new LifeEvent.Models.LifeEvent() { Id = 3, Name = "born", EventDate = new DateTime(1940, 06, 07), PersonId = 2 },
                            new LifeEvent.Models.LifeEvent() { Id = 4, Name = "first album", EventDate = new DateTime(1965, 07, 01) , PersonId = 2}

                });
            //modelBuilder.Entity<LifeEvent>().HasOne(le => le.Person).WithMany(p => p.LifeEvents).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

    }
}
