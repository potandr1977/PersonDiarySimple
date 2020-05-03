using Newtonsoft.Json;
using PersonDiary.Infrastructure.Domain.HttpApiClients;

namespace PersonDiary.Infrastructure.ApiClient.Helpers
{
    public class ResponseParser : IResponseParser
    {
        public TResult Parse<TResult>(string response)
        {
            var result = JsonConvert.DeserializeObject<TResult>(response); 

            return result;
        }
    }
}
