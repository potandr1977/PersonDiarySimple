using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Person.EventBus
{
    public class PersonSubscriberFactory : SubscriberFactory, IPersonSubscriberFactory
    {
        private const string Topic = "PersonDiarySimple.Person.EventBus";
        private const string SubscriptionId = "PersonDiarySimple.Person.EventBus.PersonSubscriber_Subscription";
        public PersonSubscriberFactory() : 
            base(Topic, SubscriptionId)
        {
        }
    }
}