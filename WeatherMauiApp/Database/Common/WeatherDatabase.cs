using SQLite;

using WeatherMauiApp.Database.Entities;

namespace WeatherMauiApp.Database.Common;
#nullable disable
public class WeatherDatabase
{
    private async Task Init()
    {
        if (_databaseConnection is not null)
            return;

        _databaseConnection = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
        var result = await _databaseConnection.CreateTableAsync<FavoriteCity>();
    }

    public async Task<List<FavoriteCity>> GetFavoriteCitiesAsync()
    {
        await Init();
        return await _databaseConnection.Table<FavoriteCity>().ToListAsync();
    }

    public async Task<FavoriteCity> GetFavoriteCityByIdAsync(int id)
    {
        await Init();
        return await _databaseConnection.Table<FavoriteCity>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<FavoriteCity> GetFavoriteCityByNameAsync(string name)
    {
        await Init();
        return await _databaseConnection.Table<FavoriteCity>().Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
    }

    public async Task<bool> AddToFavoriteCitiesAsync(FavoriteCity item)
    {
        await Init();

        var existingCity = await _databaseConnection.Table<FavoriteCity>().FirstOrDefaultAsync(f => f.Name.ToLower() == item.Name.ToLower());
        if (existingCity != null)
            return (await _databaseConnection.UpdateAsync(item)) > 0;
        else
            return (await _databaseConnection.InsertAsync(item)) > 0;
    }

    public async Task<bool> RemoverFromFavoriteCitiesAsync(int id)
    {
        await Init();

        var existingCity = await _databaseConnection.Table<FavoriteCity>().FirstOrDefaultAsync(f => f.Id == id);
        if (!Equals(existingCity))
            return (await _databaseConnection.DeleteAsync(existingCity)) > 0;

        return false;
    }

    #region Privates
    private SQLiteAsyncConnection _databaseConnection;
    #endregion
}