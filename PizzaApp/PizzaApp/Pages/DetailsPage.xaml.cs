using ViewModels;
namespace Pages;

public partial class DetailsPage : ContentPage
{
	private readonly DetailsViewModel _vm;
	public DetailsPage(DetailsViewModel vm)
	{
		_vm = vm;
		BindingContext = vm;
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		//var bottom = UIApplication.SharedApplication.Delegate.GetWindow().s ;
    }
}