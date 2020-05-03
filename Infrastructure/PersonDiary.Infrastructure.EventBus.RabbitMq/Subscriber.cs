using System;
using EasyNetQ;
using PersonDiary.Infrastructure.Domain.EventBus;

namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public class Subscriber<T> : ISubscriber<T> where T : class
    {
        private readonly string rabbitConnectionString;
        private readonly string topic;
        private readonly string subscriptionId;
        private readonly IBus bus;

        public Subscriber(string rabbitConnectionString, string topic, string subscriptionId)
        {
            this.rabbitConnectionString = rabbitConnectionString;
            this.topic = topic;
            this.subscriptionId = subscriptionId;
            this.bus = RabbitHutch.CreateBus(rabbitConnectionString);
        }

        public void Subscribe(Action<T> handler)
        {
            bus.Subscribe<T>(subscriptionId, handler, x => x.WithTopic(topic));
        }
    }
}