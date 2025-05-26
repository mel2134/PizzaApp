using ViewModels;

namespace Pages;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _homeViewModel;
	public HomePage(HomeViewModel homeViewModel)
	{
		_homeViewModel = homeViewModel;
		BindingContext = _homeViewModel;
		InitializeComponent();
	}
}