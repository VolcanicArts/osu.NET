using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapRequest : BaseRequest<Beatmap>
    {
        private readonly string _beatmapId;

        public BeatmapRequest(OsuClientLoginData loginData, string beatmapId) : base(loginData)
        {
            _beatmapId = beatmapId;
        }
        
        protected override string RequestUrl => $"{Endpoints.Api}/beatmaps/{_beatmapId}";
    }
}