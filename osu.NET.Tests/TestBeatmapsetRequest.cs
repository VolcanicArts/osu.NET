using System.Threading.Tasks;
using NUnit.Framework;

namespace osu.NET.Tests;

public class TestBeatmapsetRequest : BaseRequestTestScene
{
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