using System;
using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Client
{
    public class OsuClientCredentials
    {
        [JsonProperty("grant_type")]
        public const string GrantType = "client_credentials";

        [JsonProperty("scope")]
        public const string Scope = "public";

        [JsonProperty("client_id")]
        public string ClientId;

        [JsonProperty("client_secret")]
        public string ClientSecret;

        public OsuClientCredentials(string clientId, string clientSecret)
        {
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                throw new ArgumentException("Please set a clientId and clientSecret");
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}