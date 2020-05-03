using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public abstract class PublisherFactory: IPublisherFactory
    {
        private readonly string eventBusConnectionString;
        private readonly string topic;
        
        protected PublisherFactory(string topic)
        {
            this.eventBusConnectionString = Settings.ConnectionString;
            this.topic = topic;
        }
        
        public IPublisher<T> Create<T>() where T : class
        {
            return new Publisher<T>(eventBusConnectionString, topic);
        }

        
    }
}