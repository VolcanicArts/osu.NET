// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace osu.NET.Tests;

public class TestBeatmapScoresRequest
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
    public async Task TestValidBeatmapIdRequest()
    {
        var beatmapId = TestConstants.VALID_BEATMAP_ID;
        const GameMode mode = GameMode.Osu;

        var scores = await osuClient.GetBeatmapScoresAsync(beatmapId, mode);

        Assert.That(scores, Is.Not.Null);
    }

    [Test]
    public async Task TestInvalidBeatmapIdRequest()
    {
        var beatmapId = TestConstants.INVALID_BEATMAP_ID;
        const GameMode mode = GameMode.Osu;

        var scores = await osuClient.GetBeatmapScoresAsync(beatmapId, mode);

        Assert.That(scores, Is.Null);
    }
    
    [Test]
    public Task TestValidTryGetBeatmapIdRequest()
    {
        var beatmapId = TestConstants.VALID_BEATMAP_ID;
        const GameMode mode = GameMode.Osu;

        var successful = osuClient.TryGetBeatmapScores(beatmapId, mode, out var beatmapScores);
        
        Assert.That(successful, Is.True);
        Assert.That(beatmapScores, Is.Not.Null);
        return Task.CompletedTask;
    }
    
    [Test]
    public Task TestInvalidTryGetBeatmapIdRequest()
    {
        var beatmapId = TestConstants.INVALID_BEATMAP_ID;
        const GameMode mode = GameMode.Osu;

        var successful = osuClient.TryGetBeatmapScores(beatmapId, mode, out var beatmapScores);
        
        Assert.That(successful, Is.False);
        Assert.That(beatmapScores, Is.Null);
        return Task.CompletedTask;
    }
}