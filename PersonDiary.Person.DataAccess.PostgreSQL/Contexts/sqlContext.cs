﻿using Microsoft.EntityFrameworkCore;

namespace PersonDiary.Contexts
{
    //Класс контекста базы данных
    public class SqlContext : DbContext
    {
        public DbSet<Person.Models.Person> Persons { get; set; }

        public SqlContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=1;Server=127.0.0.1;Port=5433;Database=Person;Integrated Security=true;Pooling=true;"
                );
        }
        /// <summary>
        /// Устанавливаем правила удаления событий персоны с помощью Fluent API и набиваем БД тестовыми данными 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person.Models.Person>().HasData(
                new Person.Models.Person[]
                {
                    new Person.Models.Person {Id =1, Name = "Michael", Surname="Jackson"},
                    new Person.Models.Person {Id =2, Name = "Tom", Surname="Jones"}
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
