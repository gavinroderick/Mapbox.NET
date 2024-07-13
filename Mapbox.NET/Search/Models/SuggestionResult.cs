using System.Text.Json.Serialization;

namespace Mapbox.NET.Search.Models;

public class SuggestionResult
{
    [JsonPropertyName("suggestions")]
    public List<Suggestion> Suggestions { get; set; }

    [JsonPropertyName("attribution")]
    public string Attribution { get; set; }
}

public class Suggestion
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("name_preferred")]
    public string NamePreferred { get; set; }

    [JsonPropertyName("mapbox_id")]
    public string MapboxId { get; set; }

    [JsonPropertyName("feature_type")]
    public string FeatureType { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("full_address")]
    public string FullAddress { get; set; }

    [JsonPropertyName("place_formatted")]
    public string PlaceFormatted { get; set; }

    [JsonPropertyName("context")]
    public Context Context { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("maki")]
    public string Maki { get; set; }

    [JsonPropertyName("poi_category")]
    public List<string> PoiCategory { get; set; }

    [JsonPropertyName("poi_category_ids")]
    public List<string> PoiCategoryIds { get; set; }

    [JsonPropertyName("brand")]
    public string Brand { get; set; }

    [JsonPropertyName("brand_id")]
    public string BrandId { get; set; }

    [JsonPropertyName("external_ids")]
    public Dictionary<string, string> ExternalIds { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; }

    [JsonPropertyName("distance")]
    public double? Distance { get; set; }

    [JsonPropertyName("eta")]
    public double? Eta { get; set; }

    [JsonPropertyName("added_distance")]
    public double? AddedDistance { get; set; }

    [JsonPropertyName("added_time")]
    public double? AddedTime { get; set; }
}

public class Context
{
    [JsonPropertyName("country")]
    public Country Country { get; set; }

    [JsonPropertyName("region")]
    public Region Region { get; set; }

    [JsonPropertyName("postcode")]
    public Postcode Postcode { get; set; }

    [JsonPropertyName("district")]
    public District District { get; set; }

    [JsonPropertyName("place")]
    public Place Place { get; set; }

    [JsonPropertyName("locality")]
    public Locality Locality { get; set; }

    [JsonPropertyName("neighborhood")]
    public Neighborhood Neighborhood { get; set; }

    [JsonPropertyName("address")]
    public Address Address { get; set; }

    [JsonPropertyName("street")]
    public Street Street { get; set; }
}

public class Country
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("country_code_alpha_3")]
    public string CountryCodeAlpha3 { get; set; }
}

public class Region
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("region_code")]
    public string RegionCode { get; set; }

    [JsonPropertyName("region_code_full")]
    public string RegionCodeFull { get; set; }
}

public class Postcode
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class District
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Place
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Locality
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Neighborhood
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Address
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("address_number")]
    public string AddressNumber { get; set; }

    [JsonPropertyName("street_name")]
    public string StreetName { get; set; }
}

public class Street
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}