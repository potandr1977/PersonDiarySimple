using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonDiary.Contexts;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Cache.Redis;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Lifeevent.Cache;
using PersonDiary.LifeEvent.ApiClient;
using PersonDiary.LifeEvent.Business;
using PersonDiary.LifeEvent.Domain.Business.Services;
using PersonDiary.LifeEvent.Domain.DataAccess.Dao;
using PersonDiary.LifeEvent.Infrastructure.Domain;
using PersonDiary.LifeEvent.Mapping;
using PersonDiary.LifeEvent.Repositories;
using PersonDiary.Repositories.Dao;

namespace PersonDiary.LifeEvent.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddSingleton(typeof(SqlContext))
            .AddSingleton<IDbExecutorCache, DbExecutorRedis>()
            .AddSingleton<LifeEventCacheStore, LifeEventCacheStore>()
            .AddSingleton<ILifeEventRepository, LifeEventRepository>()
            .AddSingleton<IUnitOfWork, UnitOfWork>()
            .AddSingleton<ILifeEventDao, LifeEventDao>()
            .AddSingleton<ILifeEventService, LifeEventService>()
            .AddSingleton<IUriCreator, UriCreator>()
            .AddSingleton<IResponseParser, ResponseParser>()
            .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
            .AddSingleton<ILifeEventApiClient, LifeEventApiClient>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
