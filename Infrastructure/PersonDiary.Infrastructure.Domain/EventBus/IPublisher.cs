using System.Threading.Tasks;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface IPublisher<in T> where T : class
    {
        public Task PublishEventAsync(T publishedEvent);
        public void PublishEvent(T publishedEvent);
    }
}