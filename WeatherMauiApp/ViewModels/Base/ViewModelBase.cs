using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherMauiApp.ViewModels.Base;
public partial class ViewModelBase : ObservableObject
{
    public bool IsLoaded { get; set; }

    [ObservableProperty]
	[NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty]
    bool isLoaderVisible;

    [ObservableProperty]
    string loadingMessage;

    [ObservableProperty]
    bool hasNoData;

    [ObservableProperty]
    bool isRefreshing;

    public virtual INavigation Navigation { get; set; }
    public virtual void ReloadRequired() => IsLoaded = false;

    protected static bool IsInternetConnected()
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        return accessType == NetworkAccess.Internet;
    }
}