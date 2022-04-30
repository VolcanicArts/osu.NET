// Copyright (c) VolcanicArts. Licensed under the GPL-3.0 License.
// See the LICENSE file in the repository root for full license text.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace volcanicarts.osu.NET.Requests;

public class WebRequest
{
    private static readonly HttpClient client = new(new SocketsHttpHandler());

    private readonly List<KeyValuePair<string, string>> urlParameters = new();
    protected virtual string BaseURL => string.Empty;
    protected virtual string Endpoint => string.Empty;
    protected virtual HttpMethod Method => HttpMethod.Get;
    protected virtual HttpStatusCode AcceptCode => HttpStatusCode.OK;

    protected void AddParameter(string key, string value)
    {
        urlParameters.Add(new KeyValuePair<string, string>(key, value));
    }

    private string constructUrl()
    {
        var requestString = $"{BaseURL}{Endpoint}";

        if (urlParameters.Count > 0) requestString += "?";
        requestString = urlParameters.Aggregate(requestString, (current, pair) => current + $"{pair.Key}={pair.Value}&");
        requestString = requestString.TrimEnd('&');

        return requestString;
    }

    public async Task<HttpResponseMessage> PerformAsync()
    {
        PreProcess();

        var request = new HttpRequestMessage(Method, constructUrl());
        request.Content = GetContent();

        SetHeaders(request.Headers);

        var response = await client.SendAsync(request);
        if (response.StatusCode != AcceptCode) throw new WebException($"Response code was not {AcceptCode}. Was instead {response.StatusCode}");
        return response;
    }

    protected virtual void PreProcess() { }

    protected virtual void SetHeaders(HttpRequestHeaders headers) { }

    protected virtual StringContent GetContent()
    {
        return new StringContent(string.Empty);
    }
}