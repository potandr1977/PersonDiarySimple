using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.LifeEvent.Domain.DataAccess.Dao
{
    public interface ILifeEventDao
    {
        Task<List<Models.LifeEvent>> GetItemsAsync(int pageNo, int pageSize);

        Task<List<Models.LifeEvent>> GetItemsByPersonIdAsync(int personId);

        Task<Models.LifeEvent> GetItemAsync(int id);
        
        Task CreateAsync(Models.LifeEvent lifeEvent);
        
        Task UpdateAsync(Models.LifeEvent lifeEvent);
        
        Task DeleteAsync(int id);
    }
}