using PersonDiary.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonDiary.Person.Domain;

namespace PersonDiary.Person.Repositories
{
    public sealed class PersonRepository : IPersonRepository
    {
        private readonly SqlContext sqlContext;
        
        public PersonRepository(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }
        
        public async Task<List<Person.Models.Person>> GetItemsAsync(int pageNo, int pageSize)
        {
            return await sqlContext.Persons.OrderByDescending(p => p.Id).Skip(pageNo * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Person.Models.Person> GetItemAsync(int id)
        {
            return await sqlContext.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task CreateAsync(Person.Models.Person item) => await sqlContext.Persons.AddAsync(item);
        
        public Task UpdateAsync(Person.Models.Person item) =>
            Task.FromResult(sqlContext.Entry(item).State = EntityState.Modified);
        
        public async Task DeleteAsync(int id)
        {
            var person = await sqlContext.Persons.FindAsync(id);
            if (person != null)
                sqlContext.Persons.Remove(person);
        }
        
        public Task<int> SaveAsync() => sqlContext.SaveChangesAsync();
        
        public Task<int> CountAsync() => sqlContext.Persons.CountAsync();

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
