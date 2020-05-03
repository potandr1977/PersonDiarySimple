using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Person.EventBus
{
    public class PersonSubscriberFactory : SubscriberFactory, IPersonSubscriberFactory
    {
        private const string TopicReceiver = "PersonDiarySimple.Person.EventBus";
        private const string SubscriptionId = "PersonDiarySimple.Person.EventBus.PersonSubscriber";
        public PersonSubscriberFactory() : 
            base(TopicReceiver, SubscriptionId)
        {
        }
    }
}