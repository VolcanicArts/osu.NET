// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests.Osu.API;

public class RankingsRequest : OsuApiWebRequest<Rankings>
{
    private readonly GameMode gameMode;
    private readonly RankingType rankingType;

    public RankingsRequest(OsuClient client, GameMode gameMode, RankingType rankingType) :
        base(client)
    {
        this.gameMode = gameMode;
        this.rankingType = rankingType;
    }

    protected override string Endpoint => base.Endpoint + $"/rankings/{gameMode.ToString().ToLower()}/{rankingType.ToString().ToLower()}";
}