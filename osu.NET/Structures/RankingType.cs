// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Structures
{
    public enum RankingType
    {
        [JsonProperty("charts")]
        Charts,

        [JsonProperty("country")]
        Country,

        [JsonProperty("performance")]
        Performance,

        [JsonProperty("score")]
        Score
    }
}