﻿// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

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