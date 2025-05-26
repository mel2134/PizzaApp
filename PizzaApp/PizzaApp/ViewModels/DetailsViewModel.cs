using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;

namespace ViewModels
{
    [QueryProperty(nameof(Pizza),nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject
    {
        public DetailsViewModel()
        {
            
        }
        [ObservableProperty]
        private Pizza _pizza;

        private void AddToCart()
        {
            Pizza.CarQuantity++;
        }
        private void RemoveFromCart()
        {
            Pizza.CarQuantity--;
        }
    }
}
