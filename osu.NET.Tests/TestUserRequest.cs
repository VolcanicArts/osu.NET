// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System.Threading.Tasks;
using NUnit.Framework;
using volcanicarts.osu.NET.Requests;
using volcanicarts.osu.NET.Requests.Osu.API;
using volcanicarts.osu.NET.Structures;

namespace osu.NET.Tests;

public class TestUserRequest : BaseRequestTestScene
{
    [Test]
    public async Task TestValidUserIdRequest()
    {
        const string userId = TestConstants.VALID_USER_ID;
        var user = await osuClient.GetUserAsync(userId);

        Assert.That(user, Is.Not.Null);
        Assert.That(user.Id.ToString(), Is.EqualTo(userId));
    }
    
    [Test]
    public async Task TestInvalidUserIdRequest()
    {
        const string userId = TestConstants.INVALID_USER_ID;
        var user = await osuClient.GetUserAsync(userId);

        Assert.That(user, Is.Null);
    }
    
    [Test]
    public async Task TestValidUserUsernameRequest()
    {
        const string userUsername = TestConstants.VALID_USER_USERNAME;
        var user = await osuClient.GetUserAsync(userUsername, UserLookup.Username);

        Assert.That(user, Is.Not.Null);
        Assert.That(user.Username, Is.EqualTo(userUsername));
    }
    
    [Test]
    public async Task TestInvalidUserUsernameRequest()
    {
        const string userUsername = TestConstants.INVALID_USER_USERNAME;
        var user = await osuClient.GetUserAsync(userUsername, UserLookup.Username);

        Assert.That(user, Is.Null);
    }
    
    [Test]
    public async Task TestValidUserIdWithGamemodeRequest()
    {
        const string userId = TestConstants.VALID_USER_ID;
        var user = await osuClient.GetUserAsync(userId, GameMode.Osu);

        Assert.That(user, Is.Not.Null);
        Assert.That(user.Id.ToString(), Is.EqualTo(userId));
    }
    
    [Test]
    public async Task TestInvalidUserIdWithGamemodeRequest()
    {
        const string userId = TestConstants.INVALID_USER_ID;
        var user = await osuClient.GetUserAsync(userId, GameMode.Osu);

        Assert.That(user, Is.Null);
    }
    
    [Test]
    public async Task TestValidUserUsernameWithGamemodeRequest()
    {
        const string userUsername = TestConstants.VALID_USER_USERNAME;
        var user = await osuClient.GetUserAsync(userUsername, GameMode.Osu, UserLookup.Username);

        Assert.That(user, Is.Not.Null);
        Assert.That(user.Username, Is.EqualTo(userUsername));
    }
    
    [Test]
    public async Task TestInvalidUserUsernameWithGamemodeRequest()
    {
        const string userUsername = TestConstants.INVALID_USER_USERNAME;
        var user = await osuClient.GetUserAsync(userUsername, GameMode.Osu, UserLookup.Username);

        Assert.That(user, Is.Null);
    }
}