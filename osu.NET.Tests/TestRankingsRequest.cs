// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Structures;

namespace osu.NET.Tests;

public class TestRankingsRequest : BaseRequestTestScene
{
    [Test]
    public async Task TestValidRankings()
    {
        var rankings = await osuClient.GetRankingsAsync(GameMode.Osu, RankingType.Performance);

        Assert.That(rankings, Is.Not.Null);
    }
    
    [Test]
    public Task TestTryGetValidRankings()
    {
        var successful = osuClient.TryGetRankings(GameMode.Osu, RankingType.Performance, out var rankings);

        Assert.That(successful, Is.True);
        Assert.That(rankings, Is.Not.Null);
        return Task.CompletedTask;
    }
}