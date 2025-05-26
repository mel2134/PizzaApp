﻿using Pages;

namespace PizzaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        }
    }
}
