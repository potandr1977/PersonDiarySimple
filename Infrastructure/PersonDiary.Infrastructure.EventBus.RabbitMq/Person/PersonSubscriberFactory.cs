using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Infrastructure.Person.EventBus
{
    public class PersonSubscriberFactory : SubscriberFactory, IPersonSubscriberFactory
    {
        private static readonly string Topic = Settings.PersonTopic;
        private static readonly string SubscriptionId = Settings.PersonSubscriptionId;
        public PersonSubscriberFactory() : 
            base(Topic, SubscriptionId)
        {
        }
    }
}