﻿
using PersonDiary.Infrastructure.EventBus.RabbitMq;

namespace PersonDiary.Lifeevent.EventBus
{
    public class LifeEventSubscriberFactory : SubscriberFactory, ILifeEventSubscriberFactory
    {
        private const string Topic = "PersonDiarySimple.LifeEvent.EventBus";
        private const string SubscriptionId = "PersonDiarySimple.LifeEvent.EventBus_subscription";
        public LifeEventSubscriberFactory() : base(Topic, SubscriptionId)
        {
        }
    }
}