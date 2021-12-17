using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;

namespace volcanicarts.osu.NET.Structures
{
    public class BaseStructure
    {
        [JsonIgnore]
        public OsuClient OsuClient;
    }
}