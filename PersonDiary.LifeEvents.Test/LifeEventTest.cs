using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonDiary.Infrastructure.Domain;
using PersonDiary.LifeEvent.Domain.Business.Services;
using PersonDiary.LifeEvent.Domain.DataAccess.Dao;
using PersonDiary.LifeEvent.Dto;
using PersonDiary.LifeEvent.Infrastructure.Domain;
using PersonDiary.Repositories.Dao;
using PersonDiary.LifeEvent.Repositories;
using PersonDiary.LifeEvent.Mapping;

namespace LifeEventDiary.BusinessLogic.Test
{

    public class LifeEventModelTest
    {
        private ILifeEventRepository repoLifeEvent;
        private ILifeEventService lifeEventService;
        private IMapper mapper;
        private ServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            serviceProvider = new ServiceCollection()
                .AddTransient<ILifeEventRepository,LifeEventRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddSingleton<ILifeEventDao,LifeEventDao>()
                //.AddSingleton<Mapper>()
                //.AddSingleton<ILifeEventService, LifeEventService>()
                .BuildServiceProvider();
            
            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper();

            var unit = serviceProvider.GetService<IUnitOfWork>();
            repoLifeEvent = unit.LifeEvents;
            lifeEventService = serviceProvider.GetService<ILifeEventService>();
        }
        [Test, Order(0)]
        public async Task CreateAsync()
        {
            var suffix = DateTime.Now.ToString("dd.MM.yyyy_mm_HH_ss");

            var resp = await  lifeEventService.CreateAsync(new UpdateLifeEventRequest()
            {
                LifeEvent = new LifeEventDto()
                {
                    Name = $"LifeEventCreateTest_Name{suffix}",
                    EventDate = DateTime.Now
                }
            }); 
            Assert.IsTrue(resp.Messages.Count == 0);
        }
        [Test, Order(1)]
        public async Task UpdateAsync()
        {
            var lifeEventServiceTmp = serviceProvider.GetService<ILifeEventService>();
            const string updated = "_Updated";
            var lifeEventLast = await lifeEventServiceTmp.GetItemsAsync(new GetLifeEventsRequest() { PageSize = RepositoryDefaults.PageSize });
            lifeEventLast.LifeEvents.Last().Name += updated;

            await lifeEventServiceTmp.UpdateAsync(new UpdateLifeEventRequest() { LifeEvent = lifeEventLast.LifeEvents.Last() });
            var lifeEventCheck = await lifeEventServiceTmp.GetItemAsync(new GetLifeEventRequest() { Id = lifeEventLast.LifeEvents.Last().Id });
            Assert.IsTrue(lifeEventCheck.LifeEvent.Name.Contains(updated));
        }
        
        [Test, Order(2)]
        public async Task Delete()
        {
            await CreateAsync();
            var lifeEventLast = await lifeEventService.GetItemsAsync(new GetLifeEventsRequest() { PageSize = RepositoryDefaults.PageSize });
            await lifeEventService.DeleteAsync(new DeleteLifeEventRequest() { Id = lifeEventLast.LifeEvents.Last().Id });
            Assert.IsNull(await repoLifeEvent.GetItemAsync(lifeEventLast.LifeEvents.Last().Id));
        }
        
        [Test, Order(3)]
        public async Task GetItemsAsync()
        {
            var cntRepoRes = await repoLifeEvent.GetItemsAsync(0, RepositoryDefaults.PageSize);
            var cntRepo = cntRepoRes.ToList().Count;
            var cntModelRes = await lifeEventService.GetItemsAsync(new GetLifeEventsRequest()
                {PageSize = RepositoryDefaults.PageSize});
            var cntModel = cntModelRes.LifeEvents.Count;
            
            Assert.AreEqual(cntRepo, cntModel);
        }

    }
}
