using Newtonsoft.Json;

namespace volcanicarts.osu.NET.Structures
{
    public enum GameMode
    {
        [JsonProperty("fruits")]
        Fruits,

        [JsonProperty("mania")]
        Mania,

        [JsonProperty("osu")]
        Osu,

        [JsonProperty("taiko")]
        Taiko
    }
}