using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;

namespace osu.NET.Tests;

public class TestBeatmapsetRequest
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
    public async Task TestValidBeatmapsetIdRequest()
    {
        var beatmapsetId = TestConstants.VALID_BEATMAPSET_ID;
        var beatmapset = await osuClient.GetBeatmapsetAsync(beatmapsetId);

        Assert.That(beatmapset, Is.Not.Null);
        Assert.That(beatmapset.Id.ToString(), Is.EqualTo(beatmapsetId));
    }

    [Test]
    public async Task TestInvalidBeatmapsetIdRequest()
    {
        var beatmapsetId = TestConstants.INVALID_BEATMAPSET_ID;
        var beatmapset = await osuClient.GetBeatmapsetAsync(beatmapsetId);

        Assert.That(beatmapset, Is.Null);
    }
    
    [Test]
    public Task TestValidTryGetBeatmapsetIdRequest()
    {
        var beatmapsetId = TestConstants.VALID_BEATMAPSET_ID;
        var successful = osuClient.TryGetBeatmapset(beatmapsetId, out var beatmapset);

        Assert.That(successful, Is.True);
        Assert.That(beatmapset, Is.Not.Null);
        Assert.That(beatmapset.Id.ToString(), Is.EqualTo(beatmapsetId));
        return Task.CompletedTask;
    }

    [Test]
    public Task TestInvalidTryGetBeatmapsetIdRequest()
    {
        var beatmapsetId = TestConstants.INVALID_BEATMAPSET_ID;
        var successful = osuClient.TryGetBeatmapset(beatmapsetId, out var beatmapset);

        Assert.That(successful, Is.False);
        Assert.That(beatmapset, Is.Null);
        return Task.CompletedTask;
    }
}