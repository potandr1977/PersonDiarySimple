
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Lifeevent.EventBus
{
    public class LifeEventSubscriberFactory : SubscriberFactory, ILifeEventSubscriberFactory
    {
        private const string TopicReceiver = "PersonDiarySimple.LifeEvent.EventBus";
        private const string SubscriptionId = "PersonDiarySimple.LifeEvent.EventBus.LifeEventSubscriber";
        public LifeEventSubscriberFactory() : base(TopicReceiver, SubscriptionId)
        {
        }
    }
}