using System;
using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Client;

namespace osu.NET.Tests;

public class TestBeatmapsRequest
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
    public async Task TestNoBeatmaps()
    {
        var beatmaps = await osuClient.GetBeatmapsAsync(Array.Empty<string>());

        Assert.That(beatmaps, Is.Not.Null);
        Assert.That(beatmaps.Count, Is.Zero);
    }

    [Test]
    public async Task TestOneBeatmap()
    {
        var beatmapIds = new[] { TestConstants.VALID_BEATMAP_ID };
        var beatmaps = await osuClient.GetBeatmapsAsync(beatmapIds);

        Assert.That(beatmaps, Is.Not.Null);
        Assert.That(beatmaps.Count, Is.EqualTo(1));
        Assert.That(beatmaps[0].Id.ToString(), Is.EqualTo(beatmapIds[0]));
    }
    
    [Test]
    public Task TestTryGetOneValidBeatmap()
    {
        var beatmapIds = new[] { TestConstants.VALID_BEATMAP_ID };
        var successful = osuClient.TryGetBeatmaps(beatmapIds, out var beatmaps);

        Assert.That(successful, Is.True);
        Assert.That(beatmaps.Count, Is.EqualTo(1));
        Assert.That(beatmaps[0].Id.ToString(), Is.EqualTo(beatmapIds[0]));
        return Task.CompletedTask;
    }
    
    [Test]
    public Task TestTryGetOneInvalidBeatmap()
    {
        var beatmapIds = new[] { TestConstants.INVALID_BEATMAP_ID };
        var successful = osuClient.TryGetBeatmaps(beatmapIds, out var beatmaps);

        Assert.That(successful, Is.False);
        Assert.That(beatmaps.Count, Is.EqualTo(0));
        return Task.CompletedTask;
    }
    
    [Test]
    public Task TestTryGetManySingleInvalidBeatmap()
    {
        var beatmapIds = new[] { TestConstants.VALID_BEATMAP_ID, TestConstants.INVALID_BEATMAP_ID };
        var successful = osuClient.TryGetBeatmaps(beatmapIds, out var beatmaps);

        Assert.That(successful, Is.False);
        Assert.That(beatmaps.Count, Is.EqualTo(1));
        return Task.CompletedTask;
    }

    [Test]
    public async Task TestMaximumOfSameBeatmap()
    {
        const int size = 50;

        var beatmapIds = new string[size];
        for (var i = 0; i < size; i++) beatmapIds[i] = TestConstants.VALID_BEATMAP_ID;

        var beatmaps = await osuClient.GetBeatmapsAsync(beatmapIds);

        Assert.That(beatmaps, Is.Not.Null);
        Assert.That(beatmaps.Count, Is.EqualTo(1));
        Assert.That(beatmaps[0].Id.ToString(), Is.EqualTo(beatmapIds[0]));
    }

    [Test]
    public Task TestTooManyBeatmaps()
    {
        const int size = 51;
        Assert.ThrowsAsync<ArgumentException>(async () => await osuClient.GetBeatmapsAsync(new string[size]));
        return Task.CompletedTask;
    }
}