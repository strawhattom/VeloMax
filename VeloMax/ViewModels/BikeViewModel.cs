using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class BikeViewModel : ViewModelBase
    {
        public ObservableCollection<Bike> Bikes { get; }
        public BikeViewModel(List<Bike> b)
        {
            Bikes = new ObservableCollection<Bike>(b);
        }
    }
}
