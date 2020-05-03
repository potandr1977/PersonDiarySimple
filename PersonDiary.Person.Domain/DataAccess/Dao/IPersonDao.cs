using System.Collections.Generic;
using System.Threading.Tasks;


namespace PersonDiary.Person.Domain.DataAccess.Dao
{
    public interface IPersonDao
    {
        Task<List<Person.Models.Person>> GetItemsAsync(int pageNo, int pageSize);

        Task<Person.Models.Person> GetItemAsync(int id);

        Task CreateAsync(Person.Models.Person person);

        Task UpdateAsync(Person.Models.Person person);

        Task DeleteAsync(int id);

        Task DeleteBiographyAsync(int id);

        Task<int> CountAsync();
    }
}