using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Infrastructure.Domain.HttpApiClients
{
    public class HttpQuerySetting
    {
        public HttpQuerySetting(TimeSpan? timeout = null)
        {
            var defaultTimeout = new TimeSpan(0, 1, 40);
            Timeout = timeout.GetValueOrDefault(defaultTimeout);
        }

        public TimeSpan Timeout { get; set; }
    }
}
