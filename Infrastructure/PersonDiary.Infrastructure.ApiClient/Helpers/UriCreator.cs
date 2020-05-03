using PersonDiary.Infrastructure.Domain.ApiClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonDiary.Infrastructure.HttpApiClient.Helpers
{
    public class UriCreator : IUriCreator
    {
        public string Create(string host, string path)
        {
            var query = string.Empty;

            if (!string.IsNullOrEmpty(path))
            {
                var queryIndex = path.IndexOf("?", StringComparison.Ordinal);

                if (queryIndex > 0)
                {
                    query = path.Substring(queryIndex + 1);
                }
            }

            return Create(host, path, query);
        }

        public string Create(string host, string path, object queryParams)
        {
            if (queryParams == null)
            {
                return Create(host, path);
            }

            if (queryParams is IEnumerable)
            {
                throw new ArgumentException("Collection parameter is not supprted.");
            }

            var properties = queryParams.GetType().GetProperties()
                .ToDictionary(x => x.Name, x => x.GetValue(queryParams));
            return Create(host, path, properties);
        }

        public string Create(string host, string path, IEnumerable<KeyValuePair<string, object>> queryParams)
        {
            if (queryParams == null)
            {
                return Create(host, path, string.Empty);
            }

            var query = string.Join("&", queryParams.Select(FormatParam).ToArray());
            return Create(host, path, query);
        }

        public string Create(string host, string path, string query)
        {
            var uri = new UriBuilder(host + path) { Query = query };
            return uri.ToString();
        }

        private static string FormatParam(KeyValuePair<string, object> x)
        {
            return x.Key + "=" + FormatValue(x.Value);
        }

        private static string FormatValue(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            if (value is DateTime)
            {
                return GetFormattedDateTime(value);
            }
            if (value is decimal ||
                value is double ||
                value is float)
            {
                return GetFormattedNumber(value);
            }
            return value.ToString();
        }

        private static string GetFormattedDateTime(object value)
        {
            var dateTime = ((DateTime)value).ToUniversalTime();
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        private static string GetFormattedNumber(object value)
        {
            return value?.ToString().Replace(',', '.');
        }
    }
}
