using Mapbox.NET.Search.Models;

namespace Mapbox.NET.Tests.Search;

public class SearchBoxEndpointTests
{
    [Fact]
    public async Task Suggest_ReturnsNotNull()
    {
        var mapbox = new Mapbox("pk.eyJ1IjoidGhpbmdzZ2F2ZG9lcyIsImEiOiJjbHlob25pN3cwNzY2MmtyM3Fnd3JkMXRzIn0.fKO0DCgUY_HB2b1xgDpk3A");
        var res  = await mapbox.SearchBox.Suggest("test thing");
        Assert.NotNull(res);
    }
}