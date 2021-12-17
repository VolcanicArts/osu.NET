using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapRequest : BaseRequest<Beatmap>
    {
        [JsonProperty("id")]
        public string BeatmapId;

        public BeatmapRequest(OsuClientLoginData loginData, string beatmapId) : base(loginData)
        {
            BeatmapId = beatmapId;
        }

        [JsonIgnore]
        protected override string RequestUrl => $"{Endpoints.Api}/beatmaps/{BeatmapId}";
    }
}