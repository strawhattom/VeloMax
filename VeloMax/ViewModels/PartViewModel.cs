using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        public ObservableCollection<Part> Parts { get; }
        public PartViewModel(List<Part> p)
        {
            Parts = new ObservableCollection<Part>(p);     
        }
    }
}
