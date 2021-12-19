#nullable enable
using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Structures
{
    public class Rankings : BaseStructure
    {
        [JsonProperty("beatmapsets")]
        public Beatmapset[] Beatmapsets;

        [JsonProperty("ranking")]
        public UserStatistics[] Ranking;

        [JsonProperty("spotlight")]
        public Spotlight? Spotlight;

        [JsonProperty("total")]
        public int Total;
    }
}