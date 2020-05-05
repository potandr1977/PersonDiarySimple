namespace PersonDiary.Infrastructure.Domain.Cache
{
    public interface ICacheStore
    {
        void SetValue(string key, string value);

        string GetValue(string key);

        void Clear();
    }
}