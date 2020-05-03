
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Person.EventBus
{
    public class PersonPublisherFactory : PublisherFactory, IPersonPublisherFactory
    {
        private const string Topic = "PersonDiarySimple.Person.EventBus";
        public PersonPublisherFactory() : base(Topic)
        {
        }
    }
}