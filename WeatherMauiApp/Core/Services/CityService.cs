using System.Net;
using System.Text;

using WeatherMauiApp.Core.Common;
using WeatherMauiApp.Utilities;
using WeatherMauiApp.Models.ApiModels.ResponseModesl;
using System.Text.Json;

namespace WeatherMauiApp.Core.Services;
#nullable disable
public class CityService
{
    public CityService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ApiConstants.CityApiBaseUrl);
        var token = Preferences.Get(Keys.AccessToken, "").Trim();
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }

    public async ValueTask RefreshCityAccessTokenAsync()
    {
        try
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("No Internet", "Please check your internet connection and retry again.", "Ok");
                return;
            }

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiConstants.CityApiBaseUrl);

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var responseMessage = await _httpClient.PostAsync("security/oauth2/token", new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", ApiConstants.AmadeusApiKey),
                new KeyValuePair<string, string>("client_secret", ApiConstants.AmadeusApiSecret)
            }));

            string result = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                    return;

                TokenResponseApiModel data = System.Text.Json.JsonSerializer.Deserialize<TokenResponseApiModel>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                Preferences.Set(Keys.AccessToken, data.AccessToken);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            return;
        }
    }

    public async ValueTask<CityRootResponseApiModel> GetCitiesAsync(string city)
    {
        try
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("No Internet", "Please check your internet connection and retry again.", "Ok");
                return null;
            }

            var url = $"reference-data/locations/cities?keyword={city}&max=10";
            var responseMessage = await _httpClient.GetAsync(url);
            string result = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                    return new CityRootResponseApiModel();

                CityRootResponseApiModel data = System.Text.Json.JsonSerializer.Deserialize<CityRootResponseApiModel>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return data;
            }

            return null;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            return null;
        }
    }

    #region Privates
    private HttpClient _httpClient;
    #endregion
}