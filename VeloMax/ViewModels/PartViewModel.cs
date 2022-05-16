using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        public ObservableCollection<Part> Data { get; }
        public PartViewModel(List<Part> p)
        {
            Data = new ObservableCollection<Part>(p);     
        }
    }
}
