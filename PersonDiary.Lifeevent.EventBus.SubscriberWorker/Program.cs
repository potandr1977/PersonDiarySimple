using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonDiary.Infrastructure.ApiClient.Helpers;
using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using PersonDiary.Infrastructure.HttpApiClient;
using PersonDiary.Infrastructure.HttpApiClient.Helpers;
using PersonDiary.Infrastructure.Lifeevent.EventBus;
using PersonDiary.LifeEvent.ApiClient;

namespace PersonDiary.Lifeevent.EventBus.ConsumerWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                    .AddSingleton<IUriCreator, UriCreator>()
                    .AddSingleton<IResponseParser, ResponseParser>()  
                    .AddSingleton<IHttpRequestExecutor, HttpRequestExecutor>()
                    .AddSingleton<ILifeEventApiClient, LifeEventApiClient>()
                    .AddSingleton<ILifeEventSubscriberFactory, LifeEventSubscriberFactory>()
                    .AddHostedService<Worker>();
                });
    }
}