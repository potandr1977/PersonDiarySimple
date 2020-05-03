using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PersonDiary.Infrastructure.Domain.HttpApiClients
{
    public interface IHttpRequestExecutor
    {
        Task<string> GetAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null);

        Task<string> PostAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null);

        Task<string> PostAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null) where TRequest : class;

        Task<string> PutAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null);

        Task<string> PutAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null) where TRequest : class;

        Task<byte[]> SendFileAsync<TRequest>(
            string uri,
            HttpMethod httpMethod,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null) where TRequest : class;

        Task<string> UploadFileAsync(
            string uri,
            IFormFile file,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null);

        Task<string> UploadFileAsync<TRequest>(
            string uri,
            TRequest data,
            IFormFile file,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null) where TRequest : class;

        Task<string> DeleteAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null);

        Task<string> DeleteAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null) where TRequest : class;
    }
}
