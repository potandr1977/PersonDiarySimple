using PersonDiary.Infrastructure.Domain.EventBus;
using PersonDiary.Infrastructure.Domain.EventBus.Events;
using PersonDiary.Infrastructure.EventBus.RabbitMq;
using System;


namespace PersonDiary.Test.RabbitMq.Receiver
{
    class Program
    {
        private static readonly string RabbitConnectionString = Settings.ConnectionString;
        private static readonly string Topic = Settings.LifeEventTopic;
        private static readonly string SubscriptionId = Settings.LifeEventSubscriptionId;

        private static void Main(string[] args)
        {
            //ISubscriber<PersonCreate> subscriber = new Subscriber<PersonCreate>(RabbitConnectionString, Topic, SubscriptionId);

            var lifeEventSubscriberFactrory = new Infrastructure.Lifeevent.EventBus.LifeEventSubscriberFactory();
            ISubscriber<PersonCreate> subscriber = lifeEventSubscriberFactrory.Create<PersonCreate>();
            subscriber.Subscribe(PersonCreateHandler);
            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();
        }
        private static void PersonCreateHandler(PersonCreate personCreate)
        {
            Console.WriteLine($"-------   -----  {personCreate.Id}");
        }
    }
}