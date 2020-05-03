using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain
{
    public interface IRepository<T> : IDisposable
    {
        Task<List<T>> GetItemsAsync(int pageNo, int pageSize);
        
        Task<T> GetItemAsync(int id);
        
        Task CreateAsync(T item);
        
        Task UpdateAsync(T item);
        
        Task DeleteAsync(int id);
        
        Task<int> SaveAsync();
        
        Task<int> CountAsync();
    }
}
