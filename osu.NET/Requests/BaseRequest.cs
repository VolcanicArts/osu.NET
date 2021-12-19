using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BaseRequest<T> where T : BaseStructure
    {
        private readonly OsuClientLoginData _loginData;
        protected readonly List<KeyValuePair<string, string>> Parameters = new();

        protected BaseRequest(OsuClientLoginData loginData)
        {
            _loginData = loginData;
        }

        protected virtual string RequestUrl => null;

        public async Task<T> QueueAsync(OsuClient osuClient, HttpClient httpClient)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ConstructUrl(RequestUrl, Parameters));
            request.Headers.Authorization = new AuthenticationHeaderValue(_loginData.TokenType, _loginData.AccessToken);

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseAsString);
            result.OsuClient = osuClient;
            return result;
        }

        public static string ConstructUrl(string url, List<KeyValuePair<string, string>> parameters)
        {
            var builder = new StringBuilder($"{url}?");
            for (var i = 0; i < parameters.Count; i++)
            {
                builder.Append($"{parameters[i].Key}={parameters[i].Value}");
                if (i + 1 != parameters.Count) builder.Append('&');
            }

            return builder.ToString();
        }
    }
}