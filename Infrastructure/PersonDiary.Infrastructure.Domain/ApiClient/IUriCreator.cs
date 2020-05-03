using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Infrastructure.Domain.ApiClient
{
    public interface IUriCreator
    {
        string Create(string host, string path);

        string Create(string host, string path, object queryParams);

        string Create(string host, string path, IEnumerable<KeyValuePair<string, object>> queryParams);

        string Create(string host, string path, string query);
    }
}
