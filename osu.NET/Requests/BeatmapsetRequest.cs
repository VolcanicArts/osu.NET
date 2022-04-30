// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests;

public class BeatmapsetRequest : OsuWebRequest<Beatmapset>
{
    private readonly string beatmapsetId;

    public BeatmapsetRequest(OsuClient client, string beatmapsetId) : base(client)
    {
        this.beatmapsetId = beatmapsetId;
    }

    protected override string Endpoint => $"/beatmapsets/{beatmapsetId}";
}