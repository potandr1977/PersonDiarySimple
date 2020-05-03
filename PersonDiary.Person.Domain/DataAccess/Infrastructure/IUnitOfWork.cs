using System.Threading.Tasks;

namespace PersonDiary.Person.Domain
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }

        Task<int> SaveAsync();
    }
}
