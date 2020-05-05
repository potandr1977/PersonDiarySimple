using PersonDiary.Infrastructure.Domain.Cache;
using PersonDiary.Infrastucture.Domain.DataAccess;

namespace PersonDiary.Infrastructure.Cache
{
    public class CacheStore : ICacheStore
    {
        protected readonly string storePrefix;
        private readonly IDbExecutorCache dbExecutorRedis;

        public CacheStore(IDbExecutorCache dbExecutorRedis, string storePrefix)
        {
            this.dbExecutorRedis = dbExecutorRedis;
            this.storePrefix = storePrefix;
        }

        public void SetValue(string key, string value)
        {
            dbExecutorRedis.SetValue($"{storePrefix}{key}",value);
        }

        public string GetValue(string key)
        {
            return dbExecutorRedis.GetValue($"{storePrefix}{key}");
        }

        public void Clear()
        {
            dbExecutorRedis.Clear(storePrefix);
        }
    }
}