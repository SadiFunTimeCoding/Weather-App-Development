using Mopups.Pages;
using WeatherMauiApp.ViewModels;
using WeatherMauiApp.ViewModels.Popups;

namespace WeatherMauiApp.Views.Popups;
public partial class CitySearchPopup : PopupPage
{
	public CitySearchPopup(CitySearchPopupViewModel vm )
	{
		InitializeComponent();

        _vm = vm;

		BindingContext = vm;
    }

	internal void Init(HomePageViewModel parentVm)
		=> _vm.Init(parentVm);

    internal void Init(FavoriteCitiesPageViewModel parentVm)
        => _vm.Init(parentVm);

    #region Privates
    private readonly CitySearchPopupViewModel _vm;
    #endregion
}