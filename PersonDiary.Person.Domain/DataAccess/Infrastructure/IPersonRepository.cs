using PersonDiary.Infrastructure.Domain;

namespace PersonDiary.Person.Domain
{
    public interface IPersonRepository : IRepository<Person.Models.Person>
    {
    }
}
