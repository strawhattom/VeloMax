using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class OrderedViewModel : ViewModelBase
    {
        
        private OrderedPart _selectPart;
        private OrderedBike _selectBike;
        public ObservableCollection<OrderedBike> OrderedBikes { get; } // don't change it
        public ObservableCollection<OrderedPart> OrderedParts { get; } // don't change it

        public OrderedPart SelectedPart
        {
            get => _selectPart;
            set => this.RaiseAndSetIfChanged(ref _selectPart, value);
        }
        
        public OrderedBike SelectedBike
        {
            get => _selectBike;
            set => this.RaiseAndSetIfChanged(ref _selectBike, value);
        }
        public OrderedViewModel(List<OrderedBike> ob, List<OrderedPart> op)
        {
            OrderedBikes = new ObservableCollection<OrderedBike>(ob);
            OrderedParts = new ObservableCollection<OrderedPart>(op);
        }
    }
}
