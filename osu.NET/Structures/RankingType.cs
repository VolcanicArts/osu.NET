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