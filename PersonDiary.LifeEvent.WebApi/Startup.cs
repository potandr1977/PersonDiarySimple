using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonDiary.Contexts;
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
            .AddTransient(typeof(SqlContext))
            .AddTransient<ILifeEventRepository,LifeEventRepository>()
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient<ILifeEventDao,LifeEventDao>()
            .AddTransient<ILifeEventService, LifeEventService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            /*
            private readonly ILifeEventSubscriberFactory lifeEventSubscriberFactory;
            services.AddSingleton<ILifeEventSubscriberFactory, LifeEventSubscriberFactory>();
            var subscriber = lifeEventSubscriberFactory.Create<PersonCreate>();

            subscriber.Subscribe(lifeEventCreate =>
            {

                lifeEventApiClient.PersonCreatedAsync(new PersonCreateDto()
                {
                    Id = lifeEventCreate.Id
                }); //call and forget

                this.logger.LogInformation($"LifeEventCreate event received, id = {lifeEventCreate.Id}");
            });
            */
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
