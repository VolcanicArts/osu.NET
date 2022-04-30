// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;
using volcanicarts.osu.NET.Structures;

namespace volcanicarts.osu.NET.Requests;

public abstract class OsuWebRequest<T> : WebRequest where T : BaseStructure
{
    protected override string BaseURL => "https://osu.ppy.sh/api/v2";

    private readonly OsuClient client;

    protected OsuWebRequest(OsuClient client)
    {
        this.client = client;
    }

    public new async Task<T?> PerformAsync()
    {
        try
        {
            var response = await base.PerformAsync();
            var responseString = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<T>(responseString);
            if (deserializedData == null) return null;
            deserializedData.OsuClient = client;
            return deserializedData;
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