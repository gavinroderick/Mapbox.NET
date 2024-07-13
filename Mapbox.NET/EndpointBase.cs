using System.Net.Http.Json;
using System.Security.Authentication;
using System.Text.Json;
using Flurl;

namespace Mapbox.NET;

public abstract class EndpointBase
{
    protected readonly Mapbox Mapbox;
    private const string DefaultUserAgent = "Mapbox.NET";
    protected abstract string Endpoint { get; }
    protected Uri Url => Mapbox.ApiBaseUrl.AppendPathSegment(Endpoint).SetQueryParam("access_token", Mapbox.AccessToken).ToUri();

    internal EndpointBase(Mapbox mapbox)
    {
        Mapbox = mapbox;
    }

    private HttpClient GetClient()
    {
        if (string.IsNullOrWhiteSpace(Mapbox.AccessToken))
            throw new AuthenticationException("Access Token must be provided.  Please refer to <documentation-link> for more details"); // TODO(docs) - add link to readme

        var client = Mapbox.HttpClientFactory is not null ? Mapbox.HttpClientFactory.CreateClient() : new HttpClient();
        client.BaseAddress = Url;
        client.DefaultRequestHeaders.UserAgent.ParseAdd(DefaultUserAgent);
        return client;
    }

    private string GetErrorMessage(string resultAsString, HttpResponseMessage response, string name, string description = "")
    {
        return $"Error at {name} ({description}) with HTTP status code: {response.StatusCode}. Content: {resultAsString ?? "<no content>"}";
    }

    protected async Task<T?> HttpGet<T>(Url url)
    {
        var response = await HttpGetRequestRaw(url);
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }

    protected async Task<T> HttpGetModern<T>(Url url)
    {
        using var client = GetClient();

        try
        {
            return await client.GetFromJsonAsync<T>(url) ?? throw new InvalidOperationException("i threw this");
        }
        catch(Exception e)
        {
            throw new Exception("oops", e);
        }
        
    }
    protected async Task<string> HttpGet(Url url)
    {
        var response = await HttpGetRequestRaw(url);
        return await response.Content.ReadAsStringAsync();
    }
    
    private async Task<HttpResponseMessage> HttpGetRequestRaw(Url url)
    {
        using var client = GetClient();

        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
            return response;

        string resultAsString;
        try
        {
            resultAsString = await response.Content.ReadAsStringAsync();
        }
        catch (Exception readError)
        {
            resultAsString = "The following error was encountered trying to read the response content" + readError;
        }

        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.Unauthorized:
                throw new AuthenticationException("Mapbox rejected your authorisation. Check your API key & try again. Full response follows: " + resultAsString);
            case System.Net.HttpStatusCode.InternalServerError:
                throw new HttpRequestException("Mapbox had an internal server error - which usually means this isn't your fault. Try again in a bit" + GetErrorMessage(resultAsString, response, url));
            case System.Net.HttpStatusCode.BadRequest:
                throw new HttpRequestException("Mapbox returned a Bad Request result - probably something wrong with this SDK! Feel free to raise an issue or a PR on GitHub!"); 
        }

        throw new HttpRequestException(GetErrorMessage(resultAsString, response, url));
    }
    
}