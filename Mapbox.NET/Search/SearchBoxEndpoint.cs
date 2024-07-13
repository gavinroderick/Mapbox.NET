using Flurl;
using Mapbox.NET.Search.Models;

namespace Mapbox.NET.Search;

public class SearchBoxEndpoint : EndpointBase, ISearchBoxEndpoint
{
    internal SearchBoxEndpoint(Mapbox mapbox) : base(mapbox) { }

    protected override string Endpoint => $"search/searchbox/{Mapbox.ApiVersion}/";

    public async Task<SuggestionResult> Suggest(string searchText)
    {
        var queryParams = new
        {
            q = searchText,
            session_token = Guid.NewGuid()
        };
        
        var url = Url
            .AppendPathSegment("suggest")
            .SetQueryParams(queryParams);
        return await HttpGetModern<SuggestionResult>(url);
    }

    public Task<string> Retrieve()
    {
        throw new NotImplementedException();
    }

    public Task<string> Forward()
    {
        throw new NotImplementedException();
    }

    public Task<string> Category()
    {
        throw new NotImplementedException();
    }

    public Task<string> ListCategories()
    {
        throw new NotImplementedException();
    }
}