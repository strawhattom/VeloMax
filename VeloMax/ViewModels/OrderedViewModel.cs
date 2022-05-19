using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class OrderedViewModel : ViewModelBase
    {
        public ObservableCollection<OrderedBike> OrderedBikes { get; } // don't change it
        public ObservableCollection<OrderedPart> OrderedParts { get; } // don't change it

        public OrderedViewModel(List<OrderedBike> ob, List<OrderedPart> op)
        {
            OrderedBikes = new ObservableCollection<OrderedBike>(ob);
            OrderedParts = new ObservableCollection<OrderedPart>(op);
        }
    }
}
