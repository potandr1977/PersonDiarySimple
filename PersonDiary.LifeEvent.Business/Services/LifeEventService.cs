using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using PersonDiary.Infrastructure.Dto;
using PersonDiary.LifeEvent.Domain.Business.Services;
using PersonDiary.LifeEvent.Domain.DataAccess.Dao;
using PersonDiary.LifeEvent.Dto;
using PersonDiary.Infrastructure.Domain.Cache;
using Newtonsoft.Json;
using PersonDiary.Lifeevent.Cache;

namespace PersonDiary.LifeEvent.Business
{
    public class LifeEventService: ILifeEventService
    {
        private readonly ILifeEventDao lifeEventDao;
        private readonly IMapper mapper;
        private readonly ICacheStore cacheStore;

        public LifeEventService(ILifeEventDao lifeEventDao, IMapper mapper, LifeEventCacheStore cacheStore)
        {
            this.lifeEventDao = lifeEventDao ?? throw new ArgumentNullException("UnitOfWorkFactory in LifeEventModel is null");
            this.mapper = mapper
                ?? throw new ArgumentNullException("Mapper in LifeEventModel is null");

            this.cacheStore = cacheStore;
        }

        public async Task<GetLifeEventsResponseDto> GetItemsAsync(GetLifeEventsRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("LifeEventModel model GetLifeEventListRequest  is invalid");
            }

            var cacheKey = GetCacheKey(request);
            var cacheValue = cacheStore.GetValue(cacheKey);

            if (cacheValue != null)
            {
                var cachedResponse = JsonConvert.DeserializeObject<GetLifeEventsResponseDto>(cacheValue);
                return cachedResponse;
            }

            var response = new GetLifeEventsResponseDto();

            try
            {
                var lifeEvents = await lifeEventDao.GetItemsAsync(request.PageNo, request.PageSize).ConfigureAwait(false);
                response.LifeEvents = lifeEvents.Select(mapper.Map<LifeEventDto>).ToList();
            }
            catch (Exception e)
            { 
                response.Messages.Add(new Message(e.Message)); 
            }

            var serializedResponse = JsonConvert.SerializeObject(response);
            cacheStore.SetValue(cacheKey, serializedResponse);
            
            return response;

        }
        
        public async Task<GetLifeEventsResponseDto> GetItemsByPersonIdAsync(GetLifeEventsByPersonIdRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("GetLifeEventListRequest  is invalid");
            }

            var resp = new GetLifeEventsResponseDto();
            try
            {
                var lifeEvents = await lifeEventDao.GetItemsByPersonIdAsync(request.personId).ConfigureAwait(false);
                resp.LifeEvents = lifeEvents.Select(mapper.Map<LifeEventDto>).ToList();
            }
            catch (Exception e)
            {
                resp.Messages.Add(new Message(e.Message));
            }
            return resp;

        }


        public async Task<GetLifeEventResponseDto> GetItemAsync(GetLifeEventRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("LifeEventModel model GetLifeEventRequest  is invalid");
            }

            var resp = new GetLifeEventResponseDto();
            
            try
            {
                resp.LifeEvent = mapper.Map<LifeEventDto>(
                    await lifeEventDao.GetItemAsync(request.Id).ConfigureAwait(false)
                );
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            
            return resp;
        }
      
        public async Task<UpdateLifeEventResponseDto> CreateAsync(UpdateLifeEventRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            }

            var resp = new UpdateLifeEventResponseDto();
            
            try
            {
                var item = mapper.Map<Models.LifeEvent>(request.LifeEvent);
                await lifeEventDao.CreateAsync(item).ConfigureAwait(false);

                cacheStore.Clear();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            
            return resp;
        }
        
        public async Task<UpdateLifeEventResponseDto> UpdateAsync(UpdateLifeEventRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            }

            var resp = new UpdateLifeEventResponseDto();
            
            try
            {
                var item = mapper.Map<Models.LifeEvent>(request.LifeEvent);
                await lifeEventDao.UpdateAsync(item).ConfigureAwait(false);

                cacheStore.Clear();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            
            return resp;
        }
        
       
        public async Task<DeleteLifeEventResponseDto> DeleteAsync(DeleteLifeEventRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("LifeEventModel model DeleteLifeEventRequest  is invalid");
            }

            var resp = new DeleteLifeEventResponseDto();
            
            try
            {
                await lifeEventDao.DeleteAsync(request.Id).ConfigureAwait(false);

                cacheStore.Clear();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            
            return resp;
        }

        public Task PersonCreatedAsync(PersonCreateDto request)
        {
            cacheStore.Clear();

            return Task.CompletedTask;
        }

        private static string GetCacheKey(GetLifeEventsRequestDto request)
        {
            return $"pageNo_{request.PageNo}_pageSize_{request.PageSize}";
        }
    }
}
