using System.Collections.Generic;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapScoresRequest : BaseRequest<BeatmapScores>
    {
        private readonly string _beatmapId;

        public BeatmapScoresRequest(OsuClientLoginData loginData, string beatmapId, GameMode gameMode) : base(loginData)
        {
            _beatmapId = beatmapId;
            Parameters.Add(new KeyValuePair<string, string>("mode", gameMode.ToString().ToLower()));
        }

        protected override string RequestUrl => $"{Endpoints.Api}/beatmaps/{_beatmapId}/scores";
    }
}