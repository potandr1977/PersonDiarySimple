using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PersonDiary.Infrastructure.Domain.HttpApiClients;

namespace PersonDiary.Infrastructure.HttpApiClient
{
    public class HttpRequestExecutor : IHttpRequestExecutor, IDisposable
    {
        private static readonly TimeSpan InfiniteTimeout = TimeSpan.FromMilliseconds(-1.0);
        private bool disposed;
        private HttpClient httpClient;


        public HttpRequestExecutor()
        {
            httpClient = new HttpClient { Timeout = InfiniteTimeout };
            httpClient.DefaultRequestHeaders.Connection.Clear();
            httpClient.DefaultRequestHeaders.ConnectionClose = false;
            httpClient.DefaultRequestHeaders.Connection.Add("Keep-Alive");
        }

        public async Task<string> GetAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
        {
            CheckDisposed();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        public async Task<string> PostAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
        {
            CheckDisposed();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        public async Task<string> PostAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
            where TRequest : class
        {
            CheckDisposed();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            requestMessage.Content = CreateJsonContent(data);
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        public async Task<string> PutAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
        {
            CheckDisposed();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        public async Task<string> PutAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
            where TRequest : class
        {
            CheckDisposed();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) {Content = CreateJsonContent(data)};
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        private async Task<string> SendAsync(
            HttpRequestMessage requestMessage,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
        {
            
            AddHeaders(requestMessage, headers);

            if (setting == null)
            {
                setting = new HttpQuerySetting();
            }

            using var cts = new CancellationTokenSource(setting.Timeout);
            using var response = await httpClient.SendAsync(requestMessage, cts.Token).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<byte[]> SendFileAsync<TRequest>(
            string uri,
            HttpMethod httpMethod,
            TRequest data = null,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null) where TRequest : class
        {
            CheckDisposed();

            if (setting == null)
            {
                setting = new HttpQuerySetting();
            }

            using var cts = new CancellationTokenSource(setting.Timeout);
            using var requestMessage = new HttpRequestMessage(httpMethod, uri) {Version = HttpVersion.Version11};
            AddHeaders(requestMessage, headers);

            if (null != data)
            {
                requestMessage.Content = CreateJsonContent(data);
            }

            using var response = await httpClient.SendAsync(requestMessage, cts.Token).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            using var result = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var stream = new MemoryStream();
            await result.CopyToAsync(stream, cts.Token).ConfigureAwait(false);

            stream.Position = 0;

            var httpContentHeaders = response.Content.Headers;

            return stream.ToArray();
        }

        public async Task<string> UploadFileAsync(
            string uri,
            IFormFile file,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
        {
            CheckDisposed();

            using var requestContent = new MultipartFormDataContent();
            var streamContent = MapToStreamContent(file);
            requestContent.Add(streamContent, "file", file.FileName);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) {Content = requestContent};
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        public async Task<string> UploadFileAsync<TRequest>(
            string uri,
            TRequest data,
            IFormFile file,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null) where TRequest : class
        {
            CheckDisposed();

            using var requestContent = new MultipartFormDataContent();
            var streamContent = MapToStreamContent(file);
            requestContent.Add(streamContent, "file", file.FileName);

            var jsonContent = CreateJsonContent(data);
            requestContent.Add(jsonContent, "data");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) {Content = requestContent};
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        public async Task<string> DeleteAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
        {
            CheckDisposed();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            return await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);
        }

        public async Task<string> DeleteAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> headers = null,
            HttpQuerySetting setting = null)
            where TRequest : class
        {
            CheckDisposed();

            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri)
            {
                Content = CreateJsonContent(data)
            };
            var result = await SendAsync(requestMessage, headers, setting).ConfigureAwait(false);

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }

            disposed = true;
        }

        private void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("HttpRequestExecutor");
            }
        }

        private static StreamContent MapToStreamContent(IFormFile file)
        {
            var streamContent = new StreamContent(file.OpenReadStream());
            streamContent.Headers.Add("Content-Type", file.ContentType);

            return streamContent;
        }

        private HttpContent CreateJsonContent<TRequest>(TRequest data)
        {
            return new StringContent(JsonConvert.SerializeObject(data));
        }

        private static HttpContent CreateFormUrlEncodedContent(IReadOnlyList<KeyValuePair<string, string>> data)
        {
            try
            {
                return new FormUrlEncodedContent(data);
            }
            catch (UriFormatException)
            {
                var content = new MultipartFormDataContent();
                foreach (var keyValuePair in data)
                {
                    content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                }

                return content;
            }
        }

        private static void AddHeaders(
            HttpRequestMessage requestMessage,
            IReadOnlyCollection<KeyValuePair<string, string>> headers)
        {
            if (headers == null)
            {
                return;
            }

            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }
        }
    }
}
