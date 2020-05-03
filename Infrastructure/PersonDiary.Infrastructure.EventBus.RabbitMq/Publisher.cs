using System.Threading.Tasks;
using EasyNetQ;
using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public class Publisher<T>: IPublisher<T> where T : class
    {
        private readonly string rabbitConnectionString;
        private readonly string topic;

        public Publisher(string rabbitConnectionString, string topic)
        {
            this.topic = topic;
            this.rabbitConnectionString = rabbitConnectionString;
        }

        public Task PublishEventAsync(T publishedEvent)
        {
            using var bus = RabbitHutch.CreateBus(rabbitConnectionString);
            return bus.PublishAsync(publishedEvent, topic);
        }
        public void PublishEvent(T publishedEvent)
        {
            using var bus = RabbitHutch.CreateBus(rabbitConnectionString);
            bus.Publish(publishedEvent, topic);
        }
    }
}