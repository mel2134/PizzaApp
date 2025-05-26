using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;
using Pages;
using Services;

namespace ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly PizzaService _pizzaService;
        public HomeViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetPopularPizzas());
        }
        public ObservableCollection<Pizza> Pizzas { get; set; }
        [RelayCommand]
        private async Task GoToAllPizzasPage(bool s = false)
        {
            await Shell.Current.GoToAsync(nameof(AllPizzasPage), animate:true, new Dictionary<string, object> { [nameof(AllPizzasViewModel.FromSearch)] = s});
        }
    }
}
