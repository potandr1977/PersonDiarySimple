namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface ISubscriberFactory
    {
        ISubscriber<T> Create<T>() where T : class;
    }
}