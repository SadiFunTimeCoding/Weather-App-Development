namespace WeatherMauiApp.Models.BindingModels;
#nullable disable
public class CityModel
{
    public int Id { get; set; }
    public string CountryCode { get; set; }
    public string Country { get; set; }
    public string Name { get; set; }
    public double? CurrentTemC { get; set; }
    public string CurrentCondition { get; set; }
    public string Icon { get; set; }
}