using System.Diagnostics.CodeAnalysis;
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
        public string ClientId { get; private set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; private set; }

        public OsuClientCredentials([NotNull] string clientId, [NotNull] string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}