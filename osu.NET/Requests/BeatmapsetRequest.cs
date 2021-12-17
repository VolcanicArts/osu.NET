using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapsetRequest : BaseRequest<Beatmapset>
    {
        [JsonProperty("id")]
        public string BeatmapsetId;

        public BeatmapsetRequest(OsuClientLoginData loginData, string beatmapsetId) : base(loginData)
        {
            BeatmapsetId = beatmapsetId;
        }

        [JsonIgnore]
        protected override string RequestUrl => $"{Endpoints.Api}/beatmapsets/{BeatmapsetId}";
    }
}