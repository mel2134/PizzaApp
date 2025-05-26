using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Services
{
    public class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>()
        {
            new()
            {
                Name = "Pizza 1",
                Image = "pizza1.png",
                Price = 5.1
            },
            new()
            {
                Name = "Pizza 2",
                Image = "pizza1234.png",
                Price = 56.1
            },
            new()
            {
                Name = "Pizza 3",
                Image = "pizza2.png",
                Price = 511.1
            },
            new()
            {
                Name = "Pizza 4",
                Image = "pizza3.png",
                Price = 5.1
            },
        };
        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;
        public IEnumerable<Pizza> GetPopularPizzas(int count = 6) => _pizzas.OrderBy(p => Guid.NewGuid()).Take(count);
        public IEnumerable<Pizza> GetPizzas(string search) => string.IsNullOrWhiteSpace(search) ? _pizzas : _pizzas.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
