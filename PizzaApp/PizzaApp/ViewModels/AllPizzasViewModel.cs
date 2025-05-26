using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;
using Services;

namespace ViewModels
{
    [QueryProperty(nameof(FromSearch),nameof(FromSearch))]
    public partial class AllPizzasViewModel : ObservableObject
    {
        private readonly PizzaService _pizzaService;
        public AllPizzasViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetAllPizzas());
        }
        public ObservableCollection<Pizza> Pizzas { get; set; }
        [ObservableProperty]
        private bool _fromSearch;
        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchPizzas(string search)
        {
            Pizzas.Clear();
            Searching = true;
            foreach (var pizza in _pizzaService.GetPizzas(search)) Pizzas.Add(pizza);
            Searching = false;
        }
    }
}
