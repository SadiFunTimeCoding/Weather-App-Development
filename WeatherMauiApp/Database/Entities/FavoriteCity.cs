using SQLite;

namespace WeatherMauiApp.Database.Entities;
#nullable disable
public class FavoriteCity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed]
    public string Name { get; set; }

    public string CountryCode { get; set; }
}
