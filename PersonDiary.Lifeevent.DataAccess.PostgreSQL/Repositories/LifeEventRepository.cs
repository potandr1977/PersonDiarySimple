using Microsoft.EntityFrameworkCore;
using PersonDiary.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonDiary.LifeEvent.Infrastructure.Domain;

namespace PersonDiary.LifeEvent.Repositories
{
    public sealed class LifeEventRepository : ILifeEventRepository
    {
        private readonly SqlContext sqlContext;
        public LifeEventRepository(SqlContext db) =>this.sqlContext = db;

        public Task<List<LifeEvent.Models.LifeEvent>> GetItemsAsync(int pageNo, int pageSize) =>
             sqlContext.LifeEvents.OrderByDescending(p => p.Id).Skip(pageNo * pageSize).Take(pageSize).ToListAsync();
        
        public Task<List<LifeEvent.Models.LifeEvent>> GetItemsByPersonIdAsync(int personId) => 
            sqlContext.LifeEvents.Where(i => i.PersonId == personId).ToListAsync();
        
        public Task<LifeEvent.Models.LifeEvent> GetItemAsync(int id) => 
            sqlContext.LifeEvents.FirstOrDefaultAsync(le => le.Id == id);
        
        public async Task CreateAsync(LifeEvent.Models.LifeEvent item) => await sqlContext.LifeEvents.AddAsync(item);
        
        public Task UpdateAsync(LifeEvent.Models.LifeEvent item) => 
            Task.FromResult(sqlContext.Entry(item).State = EntityState.Modified);
        
        public async Task DeleteAsync(int id)
        {
            var lifeEvent = await sqlContext.LifeEvents.FindAsync(id);
            if (lifeEvent !=null )
                sqlContext.LifeEvents.Remove(lifeEvent);
        }

        public async Task<int> SaveAsync() => await sqlContext.SaveChangesAsync();
        
        public Task<int> CountAsync()=> sqlContext.LifeEvents.CountAsync();
        
        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    sqlContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
