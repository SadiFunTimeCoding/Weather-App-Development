using Newtonsoft.Json;
using System.Net;

using WeatherMauiApp.Core.Common;
using WeatherMauiApp.Models.ApiModels.ResponseModesl;

namespace WeatherMauiApp.Core.Services;
#nullable disable
public class WeatherService
{
    public WeatherService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ApiConstants.WeatherApiBaseUrl);
    }

    public async ValueTask<ForecastJsonResponseApiModel> GetWeatherUpdateByCityAsync(string city, int days = 7, int hours = 24)
    {
        try
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("No Internet", "Please check your internet connection and retry again.", "Ok");
                return null;
            }

            var url = $"forecast.json?q={city}&days={days}&key={ApiConstants.WeatherApiKey}";
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            string result = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                bool isResultEmpty = string.IsNullOrEmpty(result) && string.IsNullOrWhiteSpace(result);
                if (!isResultEmpty)
                {
                    ForecastJsonResponseApiModel weatherResponse = JsonConvert.DeserializeObject<ForecastJsonResponseApiModel>(result);

                    return weatherResponse;
                }

                return new ForecastJsonResponseApiModel();
            }

            return null;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            return null;
        }
    }

    public async ValueTask<ForecastJsonResponseApiModel> GetWeatherUpdateByCurrentLocationAsync(string coordinates, int days = 1, int hours = 3)
    {
        try
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("No Internet", "Please check your internet connection and retry again.", "Ok");
                return null;
            }

            var url = $"forecast.json?q={coordinates}&days={days}&key={ApiConstants.WeatherApiKey}";
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            string result = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                bool isResultEmpty = string.IsNullOrEmpty(result) && string.IsNullOrWhiteSpace(result);
                if (!isResultEmpty)
                {
                    ForecastJsonResponseApiModel weatherResponse = JsonConvert.DeserializeObject<ForecastJsonResponseApiModel>(result);

                    return weatherResponse;
                }

                return new ForecastJsonResponseApiModel();
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
    private readonly HttpClient _httpClient;
    #endregion
}