
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Infrastructure.Person.EventBus
{
    public class PersonPublisherFactory : PublisherFactory, IPersonPublisherFactory
    {
        private static readonly string Topic = Settings.PersonTopic;
        public PersonPublisherFactory() : base(Topic)
        {
        }
    }
}