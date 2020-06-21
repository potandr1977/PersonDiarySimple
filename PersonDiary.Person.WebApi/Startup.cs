using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonDiary.Contexts;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Infrastructure.Lifeevent.EventBus;
using PersonDiary.Person.ApiClient;
using PersonDiary.Person.Business;
using PersonDiary.Person.Domain;
using PersonDiary.Person.Domain.Business.Services;
using PersonDiary.Person.Domain.DataAccess.Dao;
using PersonDiary.Person.Mapping;
using PersonDiary.Person.Repositories;
using PersonDiary.Repositories.Dao;

namespace PersonDiary.Person.WebApi
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
            .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
            .AddSingleton<IUriCreator, UriCreator>()
            .AddSingleton<IResponseParser, ResponseParser>()
            .AddSingleton(typeof(SqlContext))
            .AddSingleton<ILifeEventApiClient, LifeEventApiClient>()
            .AddSingleton<IPersonRepository, PersonRepository>()
            .AddSingleton<IUnitOfWork, UnitOfWork>()
            .AddSingleton<IPersonDao, PersonDao>()
            .AddSingleton<IPersonService, PersonService>()
            .AddSingleton<IPublisherFactory, LifeEventPublisherFactory>();

            services
            .AddSingleton(provider =>
            {
                var lifeEventPublisherFactory = provider.GetService<IPublisherFactory>();
                var publisher = lifeEventPublisherFactory.Create<PersonCreate>();

                return publisher;
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
           
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
