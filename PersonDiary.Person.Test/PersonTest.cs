using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonDiary.Infrastructure.Domain;
using PersonDiary.Person.Dto;
using PersonDiary.Repositories.Dao;
using IUnitOfWork = PersonDiary.Person.Domain.IUnitOfWork;
using PersonDiary.Person.Domain;
using PersonDiary.Person.Domain.Business.Services;
using PersonDiary.Person.Repositories;
using PersonDiary.Person.Domain.DataAccess.Dao;
using PersonDiary.Person.Business;
using PersonDiary.LifeEvent.Mapping;

namespace PersonDiary.Business.Test
{

    public class PersonModelTest
    {
        IPersonRepository repoPerson;
        IPersonService _servicePerson;
        IMapper mapper;
        private ServiceProvider serviceProvider;
        
        [SetUp]
        public void Setup()
        {
            serviceProvider = new ServiceCollection()
                .AddTransient<IPersonRepository,PersonRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddSingleton<IPersonDao,PersonDao>()
                .AddSingleton<IPersonService, PersonService>()
                .BuildServiceProvider();
            
            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper();
            var unit = serviceProvider.GetService<IUnitOfWork>();
            repoPerson =  unit.Persons;
            _servicePerson = serviceProvider.GetService<IPersonService>();
        }
        [Test, Order(0)]
        public async Task Create()
        {
            var suffix = DateTime.Now.ToString("dd.MM.yyyy_mm_HH_ss");

            var resp = await _servicePerson.CreateAsync(new UpdatePersonRequestDto()
            {
                Person = new PersonDto()
                {
                    Name = $"PersonCreateTest_Name{suffix}",
                    Surname = $"PersonCreateTest_Surame{suffix}",
                }
            });
            Assert.IsTrue(resp.Messages.Count == 0);
        }
        [Test, Order(1)]
        public async void Update()
        {
            var personService = serviceProvider.GetService<IPersonService>();
            var updated = "_Updated";
            var personLastRes = await personService.GetItemsAsync(new GetPersonsRequestDto() { PageSize = RepositoryDefaults.PageSize });
            var personLast = personLastRes.Persons.Last();
            personLast.Name += updated;
            personLast.Surname += updated;

            await _servicePerson.UpdateAsync(new UpdatePersonRequestDto() { Person = personLast });
            var personCheckRes = await _servicePerson.GetItemAsync(new GetPersonRequestDto() {Id = personLast.Id});
            var personCheck = personCheckRes.Person;
            Assert.IsTrue(personCheck.Name.Contains(updated) && personCheck.Surname.Contains(updated));
        }
        [Test, Order(2)]
        public async Task Delete()
        {
            await Create();
            if (_servicePerson != null)
            {
                var personLastRes = await _servicePerson.GetItemsAsync(new GetPersonsRequestDto() { PageSize = RepositoryDefaults.PageSize });
                var personLast = personLastRes.Persons.Last();
                await _servicePerson.DeleteAsync(new DeletePersonRequestDto() { Id = personLast.Id });
                Assert.IsNull(await repoPerson.GetItemAsync(personLast.Id));
            }
        }
        [Test, Order(3)]
        public async Task GetItems()
        {
            var cntRepo = (await repoPerson.GetItemsAsync(0, RepositoryDefaults.PageSize)).ToList().Count;
            var cntModelRes = await _servicePerson.GetItemsAsync(new GetPersonsRequestDto() { PageSize = RepositoryDefaults.PageSize });
            var cntModel = cntModelRes.Persons.Count;
            Assert.AreEqual(cntRepo, cntModel);
        }
        [Test, Order(4)]
        public async Task GetItemsWithLifeEvents()
        {
/*       
            var unit = serviceProvider.GetService<IUnitOfWork>();
            var repoLifeEvents = unit.LifeEvents;
            var personsTaskRes = await _servicePerson.GetItemsAsync(new GetPersonListRequest());
            var personDao = serviceProvider.GetService<IPersonDao>();
            personsTaskRes.Persons.ForEach(async p =>
            {
               var person = await personDao.GetItemAsync(p.Id);
               Assert.AreEqual(
                   (await repoLifeEvents.GetPersonItemsAsync(p.Id)).Count(),
                   person.LifeEvents.Count
                   );
            });
*/
        }
    }
}