using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Infrastructure.Domain.HttpApiClients
{
    public interface IResponseParser
    {
        TResult Parse<TResult>(string response);
    }
}
