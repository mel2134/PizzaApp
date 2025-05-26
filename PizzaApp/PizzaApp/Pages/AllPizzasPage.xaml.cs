using System.Threading.Tasks;
using ViewModels;

namespace Pages;

public partial class AllPizzasPage : ContentPage
{
	private readonly AllPizzasViewModel _vm;
	public AllPizzasPage(AllPizzasViewModel vm)
	{
		_vm = vm;
		BindingContext = vm;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
		if (_vm.FromSearch)
		{
			await Task.Delay(100);
			searchBar.Focus();
		}
    }
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(!string.IsNullOrWhiteSpace(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
		{

			_vm.SearchPizzasCommand.Execute(null);
		}
    }
}