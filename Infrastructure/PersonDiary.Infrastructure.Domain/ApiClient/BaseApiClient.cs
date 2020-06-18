using PersonDiary.Infrastructure.Domain.ApiClient;
using PersonDiary.Infrastructure.Domain.HttpApiClients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PersonDiary.Infrastructure.HttpApiClient
{
    public abstract class BaseApiClient
    {
        private readonly HttpQuerySetting defaultSetting = new HttpQuerySetting(new TimeSpan(0, 0, 0, 30));

        private readonly IHttpRequestExecutor httpRequestExecutor;
        private readonly IUriCreator uriCreator;
        private readonly IResponseParser responseParser;

        protected BaseApiClient
            (
                IHttpRequestExecutor httpRequestExecutor,
                IUriCreator uriCreator,
                IResponseParser responseParser
            )
        {
            this.httpRequestExecutor = httpRequestExecutor;
            this.responseParser = responseParser;
            this.uriCreator = uriCreator;
        }

        protected async Task<TResponse> GetAsync<TResponse>(
            string uri,
            object queryParams = null,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri, queryParams);
            try
            {
                var response = await httpRequestExecutor.GetAsync(fullUri, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
                var result = responseParser.Parse<TResponse>(response);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task GetAsync(
            string uri,
            object queryParams = null,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri, queryParams);
           
            try
            {
                await httpRequestExecutor.GetAsync(fullUri, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
           
                throw;
            }
           
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>
            (
                string uri,
                TRequest data,
                IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
                HttpQuerySetting setting = null,
                string memberName = "",
                string sourceFilePath = "",
                int sourceLineNumber = 0
            )
            where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);
           
            try
            {
                var response = await httpRequestExecutor.PostAsync(fullUri, data, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
                var result = responseParser.Parse<TResponse>(response);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task<TResponse> PostAsync<TResponse>(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);

            try
            {
                var response = await httpRequestExecutor.PostAsync(fullUri, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
                var result = responseParser.Parse<TResponse>(response);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        protected async Task PostAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
            where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);
            
            try
            {
                await httpRequestExecutor.PostAsync(fullUri, data, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task PostAsync(
            string uri,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);
            
            try
            {
                await httpRequestExecutor.PostAsync(fullUri, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task PutAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
            where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);
            
            try
            {
                await httpRequestExecutor.PutAsync(fullUri, data, AddDefaultHeaders(queryHeaders),
                    setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task<TResponse> PutAsync<TRequest, TResponse>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
            where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);
            
            try
            {

                var response = await httpRequestExecutor.PutAsync(fullUri, data, AddDefaultHeaders(queryHeaders),
                    setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
                var result = responseParser.Parse<TResponse>(response);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task DeleteAsync(
            string uri,
            object queryParams = null,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri, queryParams);
            
            try
            {
                await httpRequestExecutor.DeleteAsync(fullUri, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task DeleteByRequestAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
            where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);
            
            try
            {
                await httpRequestExecutor
                    .DeleteAsync(fullUri, data, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting())
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        protected async Task DeleteByRequestAsync<TRequest>(
            string uri,
            object queryParams,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
            where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri, queryParams);

            try
            {
                await httpRequestExecutor
                    .DeleteAsync(fullUri, data, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting())
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected async Task<byte[]> GetFileAsync(
            string uri,
            object queryParams = null,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri, queryParams);

            try
            {
                var result = await httpRequestExecutor.SendFileAsync<object>(fullUri, HttpMethod.Get, null,
                    AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected async Task<byte[]> PostFileAsync<TRequest>(
            string uri,
            TRequest data,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
             string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0) where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);

            try
            {
                var result = await httpRequestExecutor.SendFileAsync(fullUri, HttpMethod.Post, data, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected async Task<string> SendFileAsync(
            string uri,
            IFormFile file,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
             string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);

            try
            {
                var result = await httpRequestExecutor.UploadFileAsync(fullUri, file, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected async Task<TResponse> SendFileAsync<TResponse>(
            string uri,
            IFormFile file,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);

            try
            {
                var response = await httpRequestExecutor.UploadFileAsync(fullUri, file, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
                var result = responseParser.Parse<TResponse>(response);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected async Task<TResponse> SendFileAsync<TRequest, TResponse>(
            string uri,
            TRequest data,
            IFormFile file,
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
            HttpQuerySetting setting = null,
            string memberName = "",
            string sourceFilePath = "",
            int sourceLineNumber = 0)
            where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);

            try
            {
                var response = await httpRequestExecutor.UploadFileAsync(fullUri, data, file, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
                var result = responseParser.Parse<TResponse>(response);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected async Task SendFileAsync<TRequest>
            (
                string uri,
                TRequest data,
                IFormFile file,
                IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders = null,
                HttpQuerySetting setting = null,
                string memberName = "",
                string sourceFilePath = "",
                int sourceLineNumber = 0
            ) where TRequest : class
        {
            var fullUri = uriCreator.Create(GetApiEndpoint(), uri);

            try
            {
                await httpRequestExecutor.UploadFileAsync(fullUri, data, file, AddDefaultHeaders(queryHeaders), setting ?? DefaultHttpQuerySetting()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected abstract string GetApiEndpoint();

        protected virtual IReadOnlyCollection<KeyValuePair<string, string>> DefaultHeaders()
        {
            return new[]
            {
                new KeyValuePair<string, string>("charset", "UTF-8")
            };
        }

        protected virtual HttpQuerySetting DefaultHttpQuerySetting()
        {
            return defaultSetting;
        }

        private Dictionary<string, string> AddDefaultHeaders(
            IReadOnlyCollection<KeyValuePair<string, string>> queryHeaders)
        {
            var headers = new Dictionary<string, string>();

            var defaultHeaders = DefaultHeaders();

            if (defaultHeaders != null)
            {
                foreach (var header in defaultHeaders)
                {
                    headers.Add(header.Key, header.Value);
                }
            }

            if (queryHeaders != null)
            {
                foreach (var header in queryHeaders)
                {
                    headers.Add(header.Key, header.Value);
                }
            }

            return headers;
        }

    }
}
