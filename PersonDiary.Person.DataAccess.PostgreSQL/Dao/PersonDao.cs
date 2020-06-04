using PersonDiary.Person.Domain;
using PersonDiary.Person.Domain.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.Repositories.Dao
{
    public class PersonDao: IPersonDao
    {
        private readonly IUnitOfWork unitOfWork;
        public PersonDao(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException("UnitOfWorkFactory in PersonDao is null");
        public Task<List<Person.Models.Person>> GetItemsAsync(int pageNo, int pageSize) =>
            unitOfWork.Persons.GetItemsAsync(pageNo,pageSize);

        public Task<Person.Models.Person> GetItemAsync(int id) =>
            unitOfWork.Persons.GetItemAsync(id);

        public async Task CreateAsync(Person.Models.Person person)
        {
            await unitOfWork.Persons.CreateAsync(person);
            await unitOfWork.Persons.SaveAsync();
        }

        public async Task UpdateAsync(Person.Models.Person person)
        {
            await unitOfWork.Persons.UpdateAsync(person);
            await unitOfWork.Persons.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.Persons.DeleteAsync(id);
            await unitOfWork.Persons.SaveAsync();
        }

        public async Task DeleteBiographyAsync(int id)
        {
            var person = await unitOfWork.Persons.GetItemAsync(id);
            person.Biography = null;
            await unitOfWork.Persons.UpdateAsync(person);
            await unitOfWork.Persons.SaveAsync();
        }

        public Task<int> CountAsync()
        {
            return unitOfWork.Persons.CountAsync();
        }
    }
}