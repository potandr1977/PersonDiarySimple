using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDiary.LifeEvent.Domain.DataAccess.Dao;
using PersonDiary.LifeEvent.Infrastructure.Domain;

namespace PersonDiary.Repositories.Dao
{
    public class LifeEventDao : ILifeEventDao
    {
        private readonly IUnitOfWork unitOfWork;

        public LifeEventDao(IUnitOfWork unitOfWork) =>
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException("UnitOfWorkFactory in LifeEventDao is null");
        

        public Task<List<LifeEvent.Models.LifeEvent>> GetItemsAsync(int pageNo, int pageSize) =>
            unitOfWork.LifeEvents.GetItemsAsync(pageNo,pageSize);

        public Task<List<LifeEvent.Models.LifeEvent>> GetItemsByPersonIdAsync(int personId) =>
            unitOfWork.LifeEvents.GetItemsByPersonIdAsync(personId);

        public Task<LifeEvent.Models.LifeEvent> GetItemAsync(int id) =>
            unitOfWork.LifeEvents.GetItemAsync(id);

        public async Task CreateAsync(LifeEvent.Models.LifeEvent lifeEvent) 
        {
            await unitOfWork.LifeEvents.CreateAsync(lifeEvent);
            await unitOfWork.LifeEvents.SaveAsync();
        }

        public async Task UpdateAsync(LifeEvent.Models.LifeEvent lifeEvent)
        {
            await unitOfWork.LifeEvents.UpdateAsync(lifeEvent);
            await unitOfWork.LifeEvents.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await unitOfWork.LifeEvents.DeleteAsync(id);
            await unitOfWork.LifeEvents.SaveAsync();
        }
    }
}