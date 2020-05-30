using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Domain;
using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Dto;
using PersonDiary.Person.Domain.Business.Services;
using PersonDiary.Person.Domain.DataAccess.Dao;
using PersonDiary.Person.ApiClient;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;

namespace PersonDiary.Person.Business
{
    public class PersonService: IPersonService
    {
        private readonly IPersonDao personDao;
        private readonly ILifeEventApiClient lifeEventApiClient;
        private readonly IMapper mapper;
        private readonly IPublisher<PersonCreate> personPublisher;

        public PersonService(
            IPersonDao personDao, 
            ILifeEventApiClient lifeEventApiClient, 
            IMapper mapper,
            IPublisher<PersonCreate> personPublisher)
        {
            this.personDao = personDao ?? throw new ArgumentNullException("personDao in PersonService is null");;
            this.mapper = mapper ?? throw new ArgumentNullException("Mapper in PersonService is null");
            this.lifeEventApiClient = lifeEventApiClient;
            this.personPublisher = personPublisher;
        }
       
        public async Task<GetPersonsResponseDto> GetItemsAsync(GetPersonsRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService  GetPersonListRequest is invalid");
            }

            request.PageSize = (request.PageSize == 0) ? RepositoryDefaults.PageSize : request.PageSize;
            var resp = new GetPersonsResponseDto();
            
            try
            {
                resp.Persons = mapper.Map<List<PersonDto>>(
                    await personDao.GetItemsAsync(request.PageNo, request.PageSize)
                   );
                resp.Count = await personDao.CountAsync();
            }
            catch (Exception e) { resp.AddMessage(new Message(e.Message)); }
            
            return resp;

        }
       
        public async Task<GetPersonResponseDto> GetItemAsync(GetPersonRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService GetPersonRequest  is invalid");
            }

            var resp = new GetPersonResponseDto();
            
            try
            {
                var personModel = await personDao.GetItemAsync(request.Id);
                resp.Person = mapper.Map<PersonDto>(personModel);
                var response = await lifeEventApiClient.GetLifeEventsByPersonId(request.Id);
                resp.Person.LifeEvents = response.LifeEvents;
            }
            catch (Exception e) { resp.AddMessage(new Message(e.Message)); }
            
            return resp;
        }
       
        public async Task<UpdatePersonResponseDto> CreateAsync(UpdatePersonRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService UpdatePersonRequest  is invalid");
            }

            var resp = new UpdatePersonResponseDto();
            
            try
            {
                var item = mapper.Map<Person.Models.Person>(request.Person);
                await personDao.CreateAsync(item);
                resp.Person = mapper.Map<PersonDto>(await personDao.GetItemAsync(item.Id));
            }
            catch (Exception e) { resp.AddMessage(new Message(e.Message)); };
            
            await personPublisher.PublishEventAsync(new PersonCreate() { Id = resp.Person.Id });

            return resp;
        }
       
        public async Task<UpdatePersonResponseDto> UpdateAsync(UpdatePersonRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService UpdatePersonRequest  is invalid");
            }

            var resp = new UpdatePersonResponseDto();
            
            try
            {
                var item = mapper.Map<Person.Models.Person>(request.Person);
                await personDao.UpdateAsync(item);
            }
            catch (Exception e) { resp.AddMessage(new Message(e.Message)); }
            
            return resp;
        }
       
        public async Task<DeletePersonResponseDto> DeleteAsync(DeletePersonRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService DeletePersonRequest  is invalid");
            }

            var resp = new DeletePersonResponseDto();
            
            try
            {
                await personDao.DeleteAsync(request.Id);
            }
            catch (Exception e) { resp.AddMessage(new Message(e.Message)); }
            
            return resp;
        }
       
        public async Task<PersonUploadResponseDto> UploadAsync(PersonUploadRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService PersonUploadRequest  is invalid");
            }

            var resp = new PersonUploadResponseDto();
            
            try
            {
                
                var person = await personDao.GetItemAsync(request.PersonId);
                person.Biography = request.Biography;
                await personDao.UpdateAsync(person);
            }
            catch (Exception e) { resp.AddMessage(new Message(e.Message)); }
            
            return resp;
        }
        
        public async Task<byte[]> DownloadAsync(GetPersonRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService GetPersonRequest  is invalid");
            }

            var person = await personDao.GetItemAsync(request.Id);
            
            return person.Biography;
        }
       
        public async Task<DeletePersonResponseDto> DeleteBiographyAsync(DeletePersonRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PersonService DeletePersonRequest  is invalid");
            }

            var resp = new DeletePersonResponseDto();
            
            try
            {
                var person = await personDao.GetItemAsync(request.Id);
                person.Biography = null;
                await personDao.UpdateAsync(person);
            }
            catch (Exception e) { resp.AddMessage(new Message(e.Message)); }
            
            return resp;
        }

    }
}
