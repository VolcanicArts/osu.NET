// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using volcanicarts.osu.NET.Client;

namespace volcanicarts.osu.NET.Requests.Osu.Login;

public class LoginWebRequest : OsuWebRequest
{
    private readonly OsuClientCredentials credentials;

    public LoginWebRequest(OsuClientCredentials credentials)
    {
        this.credentials = credentials;
    }

    protected override string Endpoint => "/oauth/token";
    protected override HttpMethod Method => HttpMethod.Post;

    public new async Task<OsuClientLoginData?> PerformAsync()
    {
        try
        {
            var response = await base.PerformAsync();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OsuClientLoginData>(responseString);
        }
        catch (WebException)
        {
            return null;
        }
    }

    protected override StringContent GetContent()
    {
        var contentData = JsonConvert.SerializeObject(credentials);
        return new StringContent(contentData, Encoding.UTF8, "application/json");
    }
}