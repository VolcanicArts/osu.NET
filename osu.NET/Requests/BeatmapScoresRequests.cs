// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests
{
    public class BeatmapScoresRequest : OsuWebRequest<BeatmapScores>
    {
        protected override string Endpoint => $"/beatmaps/{beatmapId}/scores";

        private readonly string beatmapId;
        private readonly GameMode gameMode;

        public BeatmapScoresRequest(OsuClient client, string beatmapId, GameMode gameMode) : base(client)
        {
            this.beatmapId = beatmapId;
            this.gameMode = gameMode;
        }

        protected override void PreProcess()
        {
            AddParameter("mode", gameMode.ToString().ToLower());
        }
    }
}