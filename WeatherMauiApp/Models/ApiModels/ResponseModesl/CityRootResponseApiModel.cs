using System.Text.Json.Serialization;

namespace WeatherMauiApp.Models.ApiModels.ResponseModesl;
#nullable disable
public class CityRootResponseApiModel
{
    [JsonPropertyName("data")]
    public List<CityResponseApiModel> Data { get; set; }
}

public class CityResponseApiModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("address")]
    public AddressResponseApiModel Address { get; set; }

    [JsonPropertyName("geoCode")]
    public GeocodeResponseApiModel GeoCode { get; set; }
}

public class GeocodeResponseApiModel
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}

public class AddressResponseApiModel
{
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
}