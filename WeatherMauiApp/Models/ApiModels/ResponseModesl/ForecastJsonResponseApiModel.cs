using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherMauiApp.Models.ApiModels.ResponseModesl;
#nullable disable
public partial class ForecastJsonResponseApiModel : ObservableObject
{
    private LocationResponseApiModel location;
    private CurrentResponseApiModel current;
    private ForecastResponseApiModel forecast;

    [JsonProperty("location")]
    public LocationResponseApiModel Location
    {
        get
        {
            return this.location;
        }
        set
        {
            this.location = value;
            OnPropertyChanged("Location");
        }
    }

    [JsonProperty("current")]
    public CurrentResponseApiModel Current
    {
        get
        {
            return this.current;
        }
        set
        {
            this.current = value;
            OnPropertyChanged("Current");
        }
    }

    [JsonProperty("forecast")]
    public ForecastResponseApiModel Forecast
    {
        get
        {
            return this.forecast;
        }
        set
        {
            this.forecast = value;
            OnPropertyChanged("Forecast");
        }
    }
}
public partial class LocationResponseApiModel : ObservableObject
{
    private string name;
    private string region;
    private string country;
    private double? lat;
    private double? lon;
    private string tzId;
    private int? localtimeEpoch;
    private string localtime;

    [JsonProperty("name")]
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
            OnPropertyChanged("Name");
        }
    }

    [JsonProperty("region")]
    public string Region
    {
        get
        {
            return this.region;
        }
        set
        {
            this.region = value;
            OnPropertyChanged("Region");
        }
    }

    [JsonProperty("country")]
    public string Country
    {
        get
        {
            return this.country;
        }
        set
        {
            this.country = value;
            OnPropertyChanged("Country");
        }
    }

    [JsonProperty("lat")]
    public double? Lat
    {
        get
        {
            return this.lat;
        }
        set
        {
            this.lat = value;
            OnPropertyChanged("Lat");
        }
    }

    [JsonProperty("lon")]
    public double? Lon
    {
        get
        {
            return this.lon;
        }
        set
        {
            this.lon = value;
            OnPropertyChanged("Lon");
        }
    }

    [JsonProperty("tz_id")]
    public string TzId
    {
        get
        {
            return this.tzId;
        }
        set
        {
            this.tzId = value;
            OnPropertyChanged("TzId");
        }
    }

    [JsonProperty("localtime_epoch")]
    public int? LocaltimeEpoch
    {
        get
        {
            return this.localtimeEpoch;
        }
        set
        {
            this.localtimeEpoch = value;
            OnPropertyChanged("LocaltimeEpoch");
        }
    }

    [JsonProperty("localtime")]
    public string Localtime
    {
        get
        {
            return this.localtime;
        }
        set
        {
            this.localtime = value;
            OnPropertyChanged("Localtime");
        }
    }
}
public partial class CurrentResponseApiModel : ObservableObject
{
    private int? lastUpdatedEpoch;
    private string lastUpdated;
    private double? tempC;
    private double? tempF;
    private int? isDay;
    private ConditionResponseApiModel condition;
    private double? windMph;
    private double? windKph;
    private int? windDegree;
    private string windDir;
    private double? pressureMb;
    private double? pressureIn;
    private double? precipMm;
    private double? precipIn;
    private int? humidity;
    private int? cloud;
    private double? feelslikeC;
    private double? feelslikeF;
    private double? visKm;
    private double? visMiles;
    private double? uv;
    private double? gustMph;
    private double? gustKph;

    [JsonProperty("last_updated_epoch")]
    public int? LastUpdatedEpoch
    {
        get
        {
            return this.lastUpdatedEpoch;
        }
        set
        {
            this.lastUpdatedEpoch = value;
            OnPropertyChanged("LastUpdatedEpoch");
        }
    }

    [JsonProperty("last_updated")]
    public string LastUpdated
    {
        get
        {
            return this.lastUpdated;
        }
        set
        {
            this.lastUpdated = value;
            OnPropertyChanged("LastUpdated");
        }
    }

    [JsonProperty("temp_c")]
    public double? TempC
    {
        get
        {
            return this.tempC;
        }
        set
        {
            this.tempC = value;
            OnPropertyChanged("TempC");
        }
    }

    [JsonProperty("temp_f")]
    public double? TempF
    {
        get
        {
            return this.tempF;
        }
        set
        {
            this.tempF = value;
            OnPropertyChanged("TempF");
        }
    }

    [JsonProperty("is_day")]
    public int? IsDay
    {
        get
        {
            return this.isDay;
        }
        set
        {
            this.isDay = value;
            OnPropertyChanged("IsDay");
        }
    }

    [JsonProperty("condition")]
    public ConditionResponseApiModel Condition
    {
        get
        {
            return this.condition;
        }
        set
        {
            this.condition = value;
            OnPropertyChanged("Condition");
        }
    }

    [JsonProperty("wind_mph")]
    public double? WindMph
    {
        get
        {
            return this.windMph;
        }
        set
        {
            this.windMph = value;
            OnPropertyChanged("WindMph");
        }
    }

    [JsonProperty("wind_kph")]
    public double? WindKph
    {
        get
        {
            return this.windKph;
        }
        set
        {
            this.windKph = value;
            OnPropertyChanged("WindKph");
        }
    }

    [JsonProperty("wind_degree")]
    public int? WindDegree
    {
        get
        {
            return this.windDegree;
        }
        set
        {
            this.windDegree = value;
            OnPropertyChanged("WindDegree");
        }
    }

    [JsonProperty("wind_dir")]
    public string WindDir
    {
        get
        {
            return this.windDir;
        }
        set
        {
            this.windDir = value;
            OnPropertyChanged("WindDir");
        }
    }

    [JsonProperty("pressure_mb")]
    public double? PressureMb
    {
        get
        {
            return this.pressureMb;
        }
        set
        {
            this.pressureMb = value;
            OnPropertyChanged("PressureMb");
        }
    }

    [JsonProperty("pressure_in")]
    public double? PressureIn
    {
        get
        {
            return this.pressureIn;
        }
        set
        {
            this.pressureIn = value;
            OnPropertyChanged("PressureIn");
        }
    }

    [JsonProperty("precip_mm")]
    public double? PrecipMm
    {
        get
        {
            return this.precipMm;
        }
        set
        {
            this.precipMm = value;
            OnPropertyChanged("PrecipMm");
        }
    }

    [JsonProperty("precip_in")]
    public double? PrecipIn
    {
        get
        {
            return this.precipIn;
        }
        set
        {
            this.precipIn = value;
            OnPropertyChanged("PrecipIn");
        }
    }

    [JsonProperty("humidity")]
    public int? Humidity
    {
        get
        {
            return this.humidity;
        }
        set
        {
            this.humidity = value;
            OnPropertyChanged("Humidity");
        }
    }

    [JsonProperty("cloud")]
    public int? Cloud
    {
        get
        {
            return this.cloud;
        }
        set
        {
            this.cloud = value;
            OnPropertyChanged("Cloud");
        }
    }

    [JsonProperty("feelslike_c")]
    public double? FeelslikeC
    {
        get
        {
            return this.feelslikeC;
        }
        set
        {
            this.feelslikeC = value;
            OnPropertyChanged("FeelslikeC");
        }
    }

    [JsonProperty("feelslike_f")]
    public double? FeelslikeF
    {
        get
        {
            return this.feelslikeF;
        }
        set
        {
            this.feelslikeF = value;
            OnPropertyChanged("FeelslikeF");
        }
    }

    [JsonProperty("vis_km")]
    public double? VisKm
    {
        get
        {
            return this.visKm;
        }
        set
        {
            this.visKm = value;
            OnPropertyChanged("VisKm");
        }
    }

    [JsonProperty("vis_miles")]
    public double? VisMiles
    {
        get
        {
            return this.visMiles;
        }
        set
        {
            this.visMiles = value;
            OnPropertyChanged("VisMiles");
        }
    }

    [JsonProperty("uv")]
    public double? Uv
    {
        get
        {
            return this.uv;
        }
        set
        {
            this.uv = value;
            OnPropertyChanged("Uv");
        }
    }

    [JsonProperty("gust_mph")]
    public double? GustMph
    {
        get
        {
            return this.gustMph;
        }
        set
        {
            this.gustMph = value;
            OnPropertyChanged("GustMph");
        }
    }

    [JsonProperty("gust_kph")]
    public double? GustKph
    {
        get
        {
            return this.gustKph;
        }
        set
        {
            this.gustKph = value;
            OnPropertyChanged("GustKph");
        }
    }
}
public partial class ForecastResponseApiModel : ObservableObject
{
    private List<ForecastDayResponseApiModel> forecastday;

    [JsonProperty("forecastday")]
    public List<ForecastDayResponseApiModel> Forecastday
    {
        get
        {
            return this.forecastday;
        }
        set
        {
            this.forecastday = value;
            OnPropertyChanged("Forecastday");
        }
    }
}
public class ForecastDayResponseApiModel : ObservableObject
{
    private string date;
    private int? dateEpoch;
    private DayResponseApiModel day;
    private AstroResponseApiModel astro;
    private List<HourResponseApiModel> hour;

    [JsonProperty("date")]
    public string Date
    {
        get
        {
            return this.date;
        }
        set
        {
            this.date = value;
            OnPropertyChanged("Date");
        }
    }

    [JsonProperty("date_epoch")]
    public int? DateEpoch
    {
        get
        {
            return this.dateEpoch;
        }
        set
        {
            this.dateEpoch = value;
            OnPropertyChanged("DateEpoch");
        }
    }


    [JsonProperty("day")]
    public DayResponseApiModel Day
    {
        get
        {
            return this.day;
        }
        set
        {
            this.day = value;
            OnPropertyChanged("Day");
        }
    }

    [JsonProperty("astro")]
    public AstroResponseApiModel Astro
    {
        get
        {
            return this.astro;
        }
        set
        {
            this.astro = value;
            OnPropertyChanged("Astro");
        }
    }

    [JsonProperty("hour")]
    public List<HourResponseApiModel> Hour
    {
        get
        {
            return this.hour;
        }
        set
        {
            this.hour = value;
            OnPropertyChanged("Hour");
        }
    }
}
public partial class DayResponseApiModel : ObservableObject
{
    private double? maxtempC;
    private double? maxtempF;
    private double? mintempC;
    private double? mintempF;
    private double? avgtempC;
    private double? avgtempF;
    private double? maxwindMph;
    private double? maxwindKph;
    private double? totalprecipMm;
    private double? totalprecipIn;
    private double? avgvisKm;
    private double? avgvisMiles;
    private double? avghumidity;
    private ConditionResponseApiModel condition;
    private double? uv;

    [JsonProperty("maxtemp_c")]
    public double? MaxtempC
    {
        get
        {
            return this.maxtempC;
        }
        set
        {
            this.maxtempC = value;
            OnPropertyChanged("MaxtempC");
        }
    }

    [JsonProperty("maxtemp_f")]
    public double? MaxtempF
    {
        get
        {
            return this.maxtempF;
        }
        set
        {
            this.maxtempF = value;
            OnPropertyChanged("MaxtempF");
        }
    }

    [JsonProperty("mintemp_c")]
    public double? MintempC
    {
        get
        {
            return this.mintempC;
        }
        set
        {
            this.mintempC = value;
            OnPropertyChanged("MintempC");
        }
    }

    [JsonProperty("mintemp_f")]
    public double? MintempF
    {
        get
        {
            return this.mintempF;
        }
        set
        {
            this.mintempF = value;
            OnPropertyChanged("MintempF");
        }
    }

    [JsonProperty("avgtemp_c")]
    public double? AvgtempC
    {
        get
        {
            return this.avgtempC;
        }
        set
        {
            this.avgtempC = value;
            OnPropertyChanged("AvgtempC");
        }
    }

    [JsonProperty("avgtemp_f")]
    public double? AvgtempF
    {
        get
        {
            return this.avgtempF;
        }
        set
        {
            this.avgtempF = value;
            OnPropertyChanged("AvgtempF");
        }
    }

    [JsonProperty("maxwind_mph")]
    public double? MaxwindMph
    {
        get
        {
            return this.maxwindMph;
        }
        set
        {
            this.maxwindMph = value;
            OnPropertyChanged("MaxwindMph");
        }
    }

    [JsonProperty("maxwind_kph")]
    public double? MaxwindKph
    {
        get
        {
            return this.maxwindKph;
        }
        set
        {
            this.maxwindKph = value;
            OnPropertyChanged("MaxwindKph");
        }
    }

    [JsonProperty("totalprecip_mm")]
    public double? TotalprecipMm
    {
        get
        {
            return this.totalprecipMm;
        }
        set
        {
            this.totalprecipMm = value;
            OnPropertyChanged("TotalprecipMm");
        }
    }

    [JsonProperty("totalprecip_in")]
    public double? TotalprecipIn
    {
        get
        {
            return this.totalprecipIn;
        }
        set
        {
            this.totalprecipIn = value;
            OnPropertyChanged("TotalprecipIn");
        }
    }

    [JsonProperty("avgvis_km")]
    public double? AvgvisKm
    {
        get
        {
            return this.avgvisKm;
        }
        set
        {
            this.avgvisKm = value;
            OnPropertyChanged("AvgvisKm");
        }
    }

    [JsonProperty("avgvis_miles")]
    public double? AvgvisMiles
    {
        get
        {
            return this.avgvisMiles;
        }
        set
        {
            this.avgvisMiles = value;
            OnPropertyChanged("AvgvisMiles");
        }
    }

    [JsonProperty("avghumidity")]
    public double? Avghumidity
    {
        get
        {
            return this.avghumidity;
        }
        set
        {
            this.avghumidity = value;
            OnPropertyChanged("Avghumidity");
        }
    }

    [JsonProperty("condition")]
    public ConditionResponseApiModel Condition
    {
        get
        {
            return this.condition;
        }
        set
        {
            this.condition = value;
            OnPropertyChanged("Condition");
        }
    }

    [JsonProperty("uv")]
    public double? Uv
    {
        get
        {
            return this.uv;
        }
        set
        {
            this.uv = value;
            OnPropertyChanged("Uv");
        }
    }
}
public partial class AstroResponseApiModel : ObservableObject
{
    private string sunrise;
    private string sunset;
    private string moonrise;
    private string moonset;

    [JsonProperty("sunrise")]
    public string Sunrise
    {
        get
        {
            return this.sunrise;
        }
        set
        {
            this.sunrise = value;
            OnPropertyChanged("Sunrise");
        }
    }

    [JsonProperty("sunset")]
    public string Sunset
    {
        get
        {
            return this.sunset;
        }
        set
        {
            this.sunset = value;
            OnPropertyChanged("Sunset");
        }
    }

    [JsonProperty("moonrise")]
    public string Moonrise
    {
        get
        {
            return this.moonrise;
        }
        set
        {
            this.moonrise = value;
            OnPropertyChanged("Moonrise");
        }
    }

    [JsonProperty("moonset")]
    public string Moonset
    {
        get
        {
            return this.moonset;
        }
        set
        {
            this.moonset = value;
            OnPropertyChanged("Moonset");
        }
    }
}
public partial class HourResponseApiModel : ObservableObject
{
    private int? timeEpoch;
    private string time;
    private double? tempC;
    private double? tempF;
    private int? isDay;
    private ConditionResponseApiModel condition;
    private double? windMph;
    private double? windKph;
    private int? windDegree;
    private string windDir;
    private double? pressureMb;
    private double? pressureIn;
    private double? precipMm;
    private double? precipIn;
    private int? humidity;
    private int? cloud;
    private double? feelslikeC;
    private double? feelslikeF;
    private double? visKm;
    private double? visMiles;
    private double? uv;
    private double? gustMph;
    private double? gustKph;

    [JsonProperty("time_epoch")]
    public int? TimeEpoch
    {
        get
        {
            return this.timeEpoch;
        }
        set
        {
            this.timeEpoch = value;
            OnPropertyChanged("TimeEpoch");
        }
    }

    [JsonProperty("time")]
    public string Time
    {
        get
        {
            return this.time;
        }
        set
        {
            this.time = value;
            OnPropertyChanged("Time");
        }
    }

    [JsonProperty("temp_c")]
    public double? TempC
    {
        get
        {
            return this.tempC;
        }
        set
        {
            this.tempC = value;
            OnPropertyChanged("TempC");
        }
    }

    [JsonProperty("temp_f")]
    public double? TempF
    {
        get
        {
            return this.tempF;
        }
        set
        {
            this.tempF = value;
            OnPropertyChanged("TempF");
        }
    }

    [JsonProperty("is_day")]
    public int? IsDay
    {
        get
        {
            return this.isDay;
        }
        set
        {
            this.isDay = value;
            OnPropertyChanged("IsDay");
        }
    }

    [JsonProperty("condition")]
    public ConditionResponseApiModel Condition
    {
        get
        {
            return this.condition;
        }
        set
        {
            this.condition = value;
            OnPropertyChanged("Condition");
        }
    }

    [JsonProperty("wind_mph")]
    public double? WindMph
    {
        get
        {
            return this.windMph;
        }
        set
        {
            this.windMph = value;
            OnPropertyChanged("WindMph");
        }
    }

    [JsonProperty("wind_kph")]
    public double? WindKph
    {
        get
        {
            return this.windKph;
        }
        set
        {
            this.windKph = value;
            OnPropertyChanged("WindKph");
        }
    }

    [JsonProperty("wind_degree")]
    public int? WindDegree
    {
        get
        {
            return this.windDegree;
        }
        set
        {
            this.windDegree = value;
            OnPropertyChanged("WindDegree");
        }
    }

    [JsonProperty("wind_dir")]
    public string WindDir
    {
        get
        {
            return this.windDir;
        }
        set
        {
            this.windDir = value;
            OnPropertyChanged("WindDir");
        }
    }

    [JsonProperty("pressure_mb")]
    public double? PressureMb
    {
        get
        {
            return this.pressureMb;
        }
        set
        {
            this.pressureMb = value;
            OnPropertyChanged("PressureMb");
        }
    }

    [JsonProperty("pressure_in")]
    public double? PressureIn
    {
        get
        {
            return this.pressureIn;
        }
        set
        {
            this.pressureIn = value;
            OnPropertyChanged("PressureIn");
        }
    }

    [JsonProperty("precip_mm")]
    public double? PrecipMm
    {
        get
        {
            return this.precipMm;
        }
        set
        {
            this.precipMm = value;
            OnPropertyChanged("PrecipMm");
        }
    }

    [JsonProperty("precip_in")]
    public double? PrecipIn
    {
        get
        {
            return this.precipIn;
        }
        set
        {
            this.precipIn = value;
            OnPropertyChanged("PrecipIn");
        }
    }

    [JsonProperty("humidity")]
    public int? Humidity
    {
        get
        {
            return this.humidity;
        }
        set
        {
            this.humidity = value;
            OnPropertyChanged("Humidity");
        }
    }

    [JsonProperty("cloud")]
    public int? Cloud
    {
        get
        {
            return this.cloud;
        }
        set
        {
            this.cloud = value;
            OnPropertyChanged("Cloud");
        }
    }

    [JsonProperty("feelslike_c")]
    public double? FeelslikeC
    {
        get
        {
            return this.feelslikeC;
        }
        set
        {
            this.feelslikeC = value;
            OnPropertyChanged("FeelslikeC");
        }
    }

    [JsonProperty("feelslike_f")]
    public double? FeelslikeF
    {
        get
        {
            return this.feelslikeF;
        }
        set
        {
            this.feelslikeF = value;
            OnPropertyChanged("FeelslikeF");
        }
    }

    [JsonProperty("vis_km")]
    public double? VisKm
    {
        get
        {
            return this.visKm;
        }
        set
        {
            this.visKm = value;
            OnPropertyChanged("VisKm");
        }
    }

    [JsonProperty("vis_miles")]
    public double? VisMiles
    {
        get
        {
            return this.visMiles;
        }
        set
        {
            this.visMiles = value;
            OnPropertyChanged("VisMiles");
        }
    }

    [JsonProperty("uv")]
    public double? Uv
    {
        get
        {
            return this.uv;
        }
        set
        {
            this.uv = value;
            OnPropertyChanged("Uv");
        }
    }

    [JsonProperty("gust_mph")]
    public double? GustMph
    {
        get
        {
            return this.gustMph;
        }
        set
        {
            this.gustMph = value;
            OnPropertyChanged("GustMph");
        }
    }

    [JsonProperty("gust_kph")]
    public double? GustKph
    {
        get
        {
            return this.gustKph;
        }
        set
        {
            this.gustKph = value;
            OnPropertyChanged("GustKph");
        }
    }
}
public partial class ConditionResponseApiModel : ObservableObject
{
    private string text;
    private string icon;
    private int? code;

    [JsonProperty("text")]
    public string Text
    {
        get
        {
            return this.text;
        }
        set
        {
            this.text = value;
            OnPropertyChanged("Text");
        }
    }

    [JsonProperty("icon")]
    public string Icon
    {
        get
        {
            return this.icon;
        }
        set
        {
            this.icon = value;
            OnPropertyChanged("Icon");
        }
    }

    [JsonProperty("code")]
    public int? Code
    {
        get
        {
            return this.code;
        }
        set
        {
            this.code = value;
            OnPropertyChanged("Code");
        }
    }
}