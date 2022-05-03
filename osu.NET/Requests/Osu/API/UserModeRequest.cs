// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests.Osu.API;

public class UserModeRequest : UserRequest
{
    private readonly GameMode mode;

    public UserModeRequest(OsuClient client, string user, GameMode mode, UserLookup lookup) : base(client, user, lookup)
    {
        this.mode = mode;
    }

    protected override string Endpoint => base.Endpoint + $"/{mode.ToString().ToLower()}";
}