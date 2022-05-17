using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        public ObservableCollection<Order> Orders { get; } // don't change it

        public OrderViewModel(List<Order> o)
        {
            Orders = new ObservableCollection<Order>(o);
        }
    }
}
