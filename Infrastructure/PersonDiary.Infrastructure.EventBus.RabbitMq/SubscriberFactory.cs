using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public class SubscriberFactory : ISubscriberFactory
    {
        private readonly string eventBusConnectionString;
        private readonly string topic;
        private readonly string subscriptionId;

        protected SubscriberFactory(string topic,string subscriptionId)
        {
            this.eventBusConnectionString = Settings.ConnectionString;
            this.topic = topic;
            this.subscriptionId = subscriptionId;
        }
        
        public ISubscriber<T> Create<T>() where T : class
        {
            return new Subscriber<T>(eventBusConnectionString, topic, subscriptionId);
        }
    }
}