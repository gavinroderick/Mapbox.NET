using Flurl;
using Mapbox.NET.Search;

namespace Mapbox.NET;

public class Mapbox
{
    public readonly IHttpClientFactory? HttpClientFactory = null;
    public readonly ISearchBoxEndpoint SearchBox;
    internal Url ApiBaseUrl { get; init; } = new Url("https://api.mapbox.com");
    internal string ApiVersion { get; init; } = "v1";
    internal string AccessToken { get; init; }
    
    public Mapbox(string? accessToken)
    {
        AccessToken = accessToken ?? "pk.eyJ1IjoidGhpbmdzZ2F2ZG9lcyIsImEiOiJjbHlob25pN3cwNzY2MmtyM3Fnd3JkMXRzIn0.fKO0DCgUY_HB2b1xgDpk3A";
        SearchBox = new SearchBoxEndpoint(this);
    }
}