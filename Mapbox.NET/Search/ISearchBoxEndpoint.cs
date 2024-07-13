using Mapbox.NET.Search.Models;

namespace Mapbox.NET.Search;

public interface ISearchBoxEndpoint
{
    public Task<SuggestionResult?> Suggest(string searchText);
    public Task<string> Retrieve();
    public Task<string> Forward();
    public Task<string> Category();
    public Task<string> ListCategories();
}