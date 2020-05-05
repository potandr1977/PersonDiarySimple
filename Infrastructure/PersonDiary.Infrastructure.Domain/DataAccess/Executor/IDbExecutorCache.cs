namespace PersonDiary.Infrastucture.Domain.DataAccess
{
    public interface IDbExecutorCache
    {
        void SetValue(string key, string value);

        string GetValue(string key);

        void Clear(string pattern);
    }
}