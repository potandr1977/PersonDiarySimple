namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface IPublisherFactory
    {
        IPublisher<T> Create<T>() where T : class;
    }
}