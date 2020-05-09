using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Infrastructure.Lifeevent.EventBus
{
    public class LifeEventPublisherFactory : PublisherFactory 
    {
        private static readonly string Topic = Settings.LifeEventTopic;
        public LifeEventPublisherFactory() : base(Topic)
        {
        }
    }
}