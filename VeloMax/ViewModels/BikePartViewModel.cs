using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class BikePartViewModel : ViewModelBase
    {
        public ObservableCollection<Part> Parts { get; }
        public BikePartViewModel(List<Part> p)
        {
            Parts = new ObservableCollection<Part>(p);     
        }
    }
}
