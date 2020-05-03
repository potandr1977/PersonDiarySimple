using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public class SubscriberFactory : ISubscriberFactory
    {
        private readonly string eventBusConnectionString;
        private readonly string topicReceiver;
        private readonly string subscriptionId;

        protected SubscriberFactory(string topicReceiver,string subscriptionId)
        {
            this.eventBusConnectionString = Settings.ConnectionString;
            this.topicReceiver = topicReceiver;
            this.subscriptionId = subscriptionId;
        }
        
        public ISubscriber<T> Create<T>() where T : class
        {
            return new Subscriber<T>(eventBusConnectionString, topicReceiver, subscriptionId);
        }
    }
}