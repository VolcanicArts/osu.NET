// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System;
using System.Collections.Generic;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests.Osu.API;

public class BeatmapsRequest : OsuApiWebRequest<BeatmapCompactArray>
{
    private readonly IReadOnlyCollection<string> beatmapIds;

    public BeatmapsRequest(OsuClient client, IReadOnlyCollection<string> beatmapIds) : base(client)
    {
        if (beatmapIds.Count > 50) throw new ArgumentException("BeatmapIds must not contain more than 50 Ids");
        this.beatmapIds = beatmapIds;
    }

    protected override string Endpoint => base.Endpoint + "/beatmaps";

    protected override void PreProcess()
    {
        foreach (var beatmapId in beatmapIds) AddParameter("ids[]", beatmapId);
    }
}