using System.Text.Json.Serialization;

namespace WeatherMauiApp.Models.ApiModels.ResponseModesl;
public class TokenResponseApiModel
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}
