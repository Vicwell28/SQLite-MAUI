using SQLite_MAUI.ViewModels;

namespace SQLite_MAUI.Views;

public partial class MainPager : ContentPage
{
	public MainPager()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}
}