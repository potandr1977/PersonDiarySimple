using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Infrastructure.EventBus.RabbitMq;
using System;

namespace PersonDiary.Test.RabbitMq.Emitter
{
    class Program
    {
        private static readonly string RabbitConnectionString = Settings.ConnectionString;
        private static readonly string Topic = Settings.LifeEventTopic;

        private static void Main(string[] args)
        {
            var input = "";
            while ((input = Console.ReadLine()) != "Quit")
            {
                //IPublisher<PersonCreate> publisher = new Publisher<PersonCreate>(RabbitConnectionString, Topic);
                var lifeEventPublisherFactory = new Infrastructure.Lifeevent.EventBus.LifeEventPublisherFactory();
                IPublisher<PersonCreate> publisher = lifeEventPublisherFactory.Create<PersonCreate>();
                if (input != null) publisher.PublishEvent(new PersonCreate {Id = int.Parse(input)});
            }
            Console.WriteLine("Published");
            Console.ReadLine();
        }
    }
}