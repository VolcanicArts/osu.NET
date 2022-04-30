// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Client;

public class OsuClientCredentials
{
    [JsonProperty("grant_type")]
    [NotNull]
    public const string GrantType = "client_credentials";

    [JsonProperty("scope")]
    [NotNull]
    public const string Scope = "public";

    public OsuClientCredentials(string clientId = "", string clientSecret = "")
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    [JsonProperty("client_id")]
    public string ClientId { get; private set; }

    [JsonProperty("client_secret")]
    public string ClientSecret { get; private set; }
}