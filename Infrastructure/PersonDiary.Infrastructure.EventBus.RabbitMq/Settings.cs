namespace PersonDiary.Infrastructure.EventBus.RabbitMq
{
    public static class Settings
    {
        public static string ConnectionString { get; } = "host=localhost";

        public static string LifeEventTopic { get; } = "PersonDiarySimple.Lifeevent.EventBus_topic";

        public static string LifeEventSubscriptionId { get; } = "PersonDiarySimple.Lifeevent.EventBus_subscription";

        public static string PersonTopic { get; } ="PersonDiarySimple.Person.EventBus_topic";

        public static string PersonSubscriptionId { get; } = "PersonDiarySimple.Person.EventBus_subscription";
    }
}