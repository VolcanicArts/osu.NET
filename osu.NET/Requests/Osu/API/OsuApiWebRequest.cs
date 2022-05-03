// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests.Osu.API;

public abstract class OsuApiWebRequest<T> : OsuWebRequest where T : class
{
    private readonly OsuClient client;

    protected OsuApiWebRequest(OsuClient client)
    {
        this.client = client;
    }

    protected override string Endpoint => "/api/v2";

    public new async Task<T?> PerformAsync()
    {
        try
        {
            var response = await base.PerformAsync();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
        catch (WebException)
        {
            return null;
        }
    }

    protected override void SetHeaders(HttpRequestHeaders headers)
    {
        headers.Authorization = new AuthenticationHeaderValue(client.loginData!.TokenType, client.loginData!.AccessToken);
    }
}