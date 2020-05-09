
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Infrastructure.Lifeevent.EventBus
{
    public class LifeEventSubscriberFactory : SubscriberFactory, ILifeEventSubscriberFactory
    {
        private static readonly string Topic = Settings.LifeEventTopic;
        private static readonly string SubscriptionId = Settings.LifeEventSubscriptionId;
        public LifeEventSubscriberFactory() : base(Topic, SubscriptionId)
        {
        }
    }
}