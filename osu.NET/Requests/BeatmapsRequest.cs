using System;
using System.Collections.Generic;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapsRequest : BaseRequest<BeatmapCompactArray>
    {
        public BeatmapsRequest(OsuClientLoginData loginData, IReadOnlyCollection<string> beatmapIds) : base(loginData)
        {
            if (beatmapIds.Count > 50) throw new ArgumentException("BeatmapIds must not contain more than 50 Ids");
            foreach (var beatmapId in beatmapIds) Parameters.Add(new KeyValuePair<string, string>("ids[]", beatmapId));
        }

        protected override string RequestUrl => $"{Endpoints.Api}/beatmaps";
    }
}