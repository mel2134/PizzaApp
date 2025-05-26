using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Models
{
    public partial class Pizza : ObservableObject
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _carQuantity;
        public double Amount => CarQuantity * Price;
        public Pizza Clone() => MemberwiseClone() as Pizza;
    }
}
