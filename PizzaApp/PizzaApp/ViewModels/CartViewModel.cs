using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;

namespace ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<Pizza> ItemRemoveD;
        public event EventHandler CartCleared;
        public ObservableCollection<Pizza> Items { get; set; } = new();
        [ObservableProperty]
        private double _total;
        private void ReCalc() => Total = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateItem(Pizza pizza)
        {
            var item = Items.FirstOrDefault(i => i.Name == pizza.Name);
            if (item != null)
            {
                item.CarQuantity = pizza.CarQuantity;
            }
            else
            {
                Items.Add(pizza.Clone());
            }
            ReCalc();
        }
        [RelayCommand]
        private void RemoveItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                Items.Remove(item);
                ReCalc();
                ItemRemoveD?.Invoke(this,item);
            }
        }
        [RelayCommand]
        private void ClearCart()
        {
            Items.Clear();
            ReCalc();
            CartCleared?.Invoke(this,EventArgs.Empty);
        }
    }
}
