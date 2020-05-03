using System.Threading.Tasks;

namespace PersonDiary.LifeEvent.Infrastructure.Domain
{
    public interface IUnitOfWork
    {
        ILifeEventRepository LifeEvents { get; }

        Task<int> SaveAsync();
    }
}
