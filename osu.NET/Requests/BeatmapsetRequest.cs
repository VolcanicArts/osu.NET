using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapsetRequest : BaseRequest<Beatmapset>
    {
        private readonly string _beatmapsetId;

        public BeatmapsetRequest(OsuClientLoginData loginData, string beatmapsetId) : base(loginData)
        {
            _beatmapsetId = beatmapsetId;
        }
        
        protected override string RequestUrl => $"{Endpoints.Api}/beatmapsets/{_beatmapsetId}";
    }
}