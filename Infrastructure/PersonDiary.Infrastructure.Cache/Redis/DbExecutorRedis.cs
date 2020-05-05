using System.Linq;
using PersonDiary.Infrastucture.Domain.DataAccess;
using StackExchange.Redis;

namespace PersonDiary.Infrastructure.Cache.Redis
{
    public class DbExecutorRedis : IDbExecutorCache
    {
        
        private const string redisHost = "localhost";
        private readonly int redisPort = 6379;
        private ConnectionMultiplexer connectionMultiplexer;
        
        public DbExecutorRedis()
        {
            Connect();
        }
        
        public void Connect()
        {
            try
            {
                var configString = $"{redisHost}:{redisPort},connectRetry=5";
                connectionMultiplexer = ConnectionMultiplexer.Connect(configString);
            }
            catch (RedisConnectionException err)
            {
                throw err;
            }
        }
        
        public void SetValue(string key, string value)
        {
            var db = connectionMultiplexer.GetDatabase();
            db.StringSet(key, value);
        }

        public string GetValue(string key)
        {
            var db = connectionMultiplexer.GetDatabase();
            
            return  db.StringGet(key);
        }

        public void Clear(string pattern)
        {
            var db = connectionMultiplexer.GetDatabase();

            foreach (var ep in connectionMultiplexer.GetEndPoints())
            {
                var server = connectionMultiplexer.GetServer(ep);
                
                var keys = server.Keys(pattern: pattern + "*").ToArray();
                db.KeyDeleteAsync(keys);
            }
        }
    }
}