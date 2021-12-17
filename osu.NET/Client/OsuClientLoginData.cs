using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Client
{
    public class OsuClientLoginData
    {
        [JsonProperty("access_token")]
        public string AccessToken;

        [JsonProperty("expires_in")]
        public int ExpiresIn;

        [JsonProperty("token_type")]
        public string TokenType;
    }
}