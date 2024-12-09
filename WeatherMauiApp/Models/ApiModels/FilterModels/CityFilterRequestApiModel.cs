using System.Text.Json.Serialization;

namespace WeatherMauiApp.Models.ApiModels.RequestModels;
#nullable disable
internal class CityFilterRequestApiModel
{
    [JsonPropertyName("country")]
    public string Country { get; set; }
}
