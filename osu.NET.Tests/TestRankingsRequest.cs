// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace osu.NET.Tests;

public class TestRankingsRequest
{
    private OsuClient osuClient;

    [SetUp]
    public async Task SetUp()
    {
        var clientId = Environment.GetEnvironmentVariable("clientId");
        var clientSecret = Environment.GetEnvironmentVariable("clientSecret");
        var osuClientCredentials = new OsuClientCredentials(clientId, clientSecret);
        osuClient = new OsuClient(osuClientCredentials);
        await osuClient.LoginAsync();
    }

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