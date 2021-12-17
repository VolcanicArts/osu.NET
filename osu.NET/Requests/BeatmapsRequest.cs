using System;
using System.Text;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;
using volcanicarts.osu.NET.Util;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapsRequest : BaseRequest<BeatmapCompactArray>
    {
        private readonly string[] _beatmapIds;

        public BeatmapsRequest(OsuClientLoginData loginData, string[] beatmapIds) : base(loginData)
        {
            if (beatmapIds.Length > 50) throw new ArgumentException("BeatmapIds must not contain more than 50 Ids");
            _beatmapIds = beatmapIds;
        }

        protected override string RequestUrl
        {
            get
            {
                var builder = new StringBuilder($"{Endpoints.Api}/beatmaps?");
                for (var i = 0; i < _beatmapIds.Length; i++)
                {
                    builder.Append($"ids[]={_beatmapIds[i]}");
                    if (i + 1 != _beatmapIds.Length) builder.Append('&');
                }

                return builder.ToString();
            }
        }
    }
}