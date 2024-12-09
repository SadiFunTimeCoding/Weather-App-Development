using System.Windows.Input;

namespace WeatherMauiApp.Views.UserControls;
public partial class SearchBarUc
{
    public SearchBarUc()
    {
        InitializeComponent();
    }

    public string ValueText
    {
        get => (string)GetValue(ValueTextProperty);
        set { SetValue(ValueTextProperty, value); }
    }
    public static readonly BindableProperty ValueTextProperty =
        BindableProperty.Create(nameof(ValueText), typeof(string), typeof(SearchBarUc), defaultValue: null);

    public Color FocusColor
    {
        get => (Color)GetValue(FocusColorProperty);
        set { SetValue(FocusColorProperty, value); }
    }
    public static readonly BindableProperty FocusColorProperty =
        BindableProperty.Create(nameof(FocusColor), typeof(Color), typeof(SearchBarUc), Color.FromArgb("#035C94"));

    public string PlaceholderText
    {
        get => (string)GetValue(PlaceholderTextProperty);
        set { SetValue(PlaceholderTextProperty, value); }
    }
    public static readonly BindableProperty PlaceholderTextProperty =
        BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(SearchBarUc), defaultBindingMode: BindingMode.TwoWay, defaultValue: "Type here");

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    public static readonly BindableProperty CommandProperty =
      BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SearchBarUc), null);

    private void SearchEntry_Completed(object sender, EventArgs e) => Command?.Execute(((Entry)sender).Text);

    public ICommand TapCommand
    {
        get { return (ICommand)GetValue(TapCommandProperty); }
        set { SetValue(TapCommandProperty, value); }
    }
    public static readonly BindableProperty TapCommandProperty =
      BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(SearchBarUc), null);
}
