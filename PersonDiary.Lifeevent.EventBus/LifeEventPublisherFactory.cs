using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Lifeevent.EventBus
{
    public class LifeEventPublisherFactory : PublisherFactory 
    {
        private const string Topic = "PersonDiarySimple.Lifeevent.EventBus";
        public LifeEventPublisherFactory() : base(Topic)
        {
        }

        public IPublisher<T> Create<T>() where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}