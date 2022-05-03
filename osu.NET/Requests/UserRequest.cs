// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests;

public class UserRequest : OsuWebRequest<User>
{
    private readonly string user;
    private readonly UserLookup? lookup;

    public UserRequest(OsuClient client, string user, UserLookup lookup) : base(client)
    {
        this.user = user;
        this.lookup = lookup;
    }

    protected override void PreProcess()
    {
        base.PreProcess();
        AddParameter("key", lookup.ToString()!.ToLower());
    }

    protected override string Endpoint => $"/users/{user}";
}