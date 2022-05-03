// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests.Osu.API;

public class BeatmapRequest : OsuApiWebRequest<Beatmap>
{
    private readonly string beatmapId;

    public BeatmapRequest(OsuClient client, string beatmapId) : base(client)
    {
        this.beatmapId = beatmapId;
    }

    protected override string Endpoint => base.Endpoint + $"/beatmaps/{beatmapId}";
}