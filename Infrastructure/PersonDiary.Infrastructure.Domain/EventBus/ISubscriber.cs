using System;

namespace PersonDiary.Infrastructure.Domain.EventBus
{
    public interface ISubscriber<out T> where T : class
    {
        void Subscribe(Action<T> handler); 
    }
}