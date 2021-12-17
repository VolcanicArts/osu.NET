using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests
{
    public class BaseRequest<T> where T : BaseStructure
    {
        private readonly OsuClientLoginData _loginData;

        protected BaseRequest(OsuClientLoginData loginData)
        {
            _loginData = loginData;
        }

        protected virtual string RequestUrl => null;

        public async Task<T> QueueAsync(OsuClient osuClient, HttpClient httpClient)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, RequestUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue(_loginData.TokenType, _loginData.AccessToken);

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseAsString);
            result.OsuClient = osuClient;
            return result;
        }
    }
}