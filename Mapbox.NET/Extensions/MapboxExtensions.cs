using Microsoft.Extensions.DependencyInjection;

namespace Mapbox.NET.Extensions;

public static class MapboxExtensions
{
    public static IServiceCollection AddMapbox(this IServiceCollection serviceCollection, string accessToken)
    {
        serviceCollection.AddHttpClient("MapboxApiClient",
            client =>
            {
                client.BaseAddress = new Uri("https://api.mapbox.com/");
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mapbox.NET");
            });
        
        Environment.SetEnvironmentVariable("MAPBOX_ACCESS_TOKEN", accessToken);
        return serviceCollection;
    }
}