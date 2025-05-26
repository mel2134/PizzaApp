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
}