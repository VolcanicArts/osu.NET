using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;

namespace osu.NET.Tests;

public class TestBeatmapRequest
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
        var beatmap = await osuClient.GetBeatmapAsync(beatmapId);

        Assert.That(beatmap, Is.Not.Null);
        Assert.That(beatmap.Id.ToString(), Is.EqualTo(beatmapId));
    }
    
    [Test]
    public Task TestValidBeatmapIdTryGet()
    {
        var beatmapId = TestConstants.VALID_BEATMAP_ID;
        var beatmapExists = osuClient.TryGetBeatmap(beatmapId, out var beatmap);
        
        Assert.That(beatmapExists, Is.True);
        Assert.That(beatmap, Is.Not.Null);
        Assert.That(beatmap.Id.ToString(), Is.EqualTo(beatmapId));
        return Task.CompletedTask;
    }

    [Test]
    public async Task TestInvalidBeatmapIdRequest()
    {
        var beatmapId = TestConstants.INVALID_BEATMAP_ID;
        var beatmap = await osuClient.GetBeatmapAsync(beatmapId);

        Assert.That(beatmap, Is.Null);
    }
    
    [Test]
    public Task TestInvalidBeatmapIdTryGet()
    {
        var beatmapId = TestConstants.INVALID_BEATMAP_ID;
        var beatmapExists = osuClient.TryGetBeatmap(beatmapId, out var beatmap);
        
        Assert.That(beatmapExists, Is.False);
        Assert.That(beatmap, Is.Null);
        return Task.CompletedTask;
    }
}