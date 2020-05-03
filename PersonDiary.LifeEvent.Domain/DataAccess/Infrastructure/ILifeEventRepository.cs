using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Domain;

namespace PersonDiary.LifeEvent.Infrastructure.Domain
{
    public interface ILifeEventRepository : IRepository<Models.LifeEvent>
    {
        Task<List<Models.LifeEvent>> GetItemsByPersonIdAsync(int personId);
    }
}
