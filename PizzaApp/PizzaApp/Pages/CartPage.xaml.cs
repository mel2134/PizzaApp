using System.Threading.Tasks;
using ViewModels;

namespace Pages;

public partial class CartPage : ContentPage
{
	private readonly CartViewModel _vm;
	public CartPage(CartViewModel vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AllPizzasPage));
    }
}