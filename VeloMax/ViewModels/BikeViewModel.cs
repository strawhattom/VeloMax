using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class BikeViewModel : ViewModelBase
    {
        public ObservableCollection<Bike> Data { get; }
        public BikeViewModel(List<Bike> b)
        {
            Data = new ObservableCollection<Bike>(b);
        }
    }
}
