using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;
using Pages;

namespace ViewModels
{
    [QueryProperty(nameof(Pizza),nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
            _cartViewModel.CartCleared += OnCart;
            _cartViewModel.ItemRemoveD += OnRemove;
        }
        private void OnCart(object? sender, EventArgs e) => Pizza.CarQuantity = 0;
        private void OnRemove(object? sender, Pizza p) => OnItem(p, 0);
        private void OnItem(Pizza p,int q)
        {
            if(p.Name == Pizza.Name)
            {
                Pizza.CarQuantity = q;
            }
        }

        [ObservableProperty]
        private Pizza _pizza;
        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CarQuantity++;
            _cartViewModel.UpdateItemCommand.Execute(Pizza);
        }
        [RelayCommand]
        private void RemoveFromCart()
        {
            if(Pizza.CarQuantity > 0)
            {
                Pizza.CarQuantity--;
                _cartViewModel.UpdateItemCommand.Execute(Pizza);
            }
            ;
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if(Pizza.CarQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Please add pizzas to your cart!","OK");
                //await Toast.Make("Please add pizzas to your cart!",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
        }
        public void Dispose()
        {
            _cartViewModel.ItemRemoveD -= OnRemove;
            _cartViewModel.CartCleared -= OnCart;
        }
    }
}
