using PersonDiary.Infrastructure.Cache;
using PersonDiary.Infrastucture.Domain.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Lifeevent.Cache
{
    public class LifeEventCacheStore: CacheStore, ILifeEventCacheStore
    {
        public LifeEventCacheStore(IDbExecutorCache dbExecutorRedis) : base(dbExecutorRedis, "lifeeventstore")
        { 
        }
    }
}
