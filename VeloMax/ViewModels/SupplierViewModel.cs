using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class SupplierViewModel : ViewModelBase
    {
        public ObservableCollection<Supplier> Data { get; }
        public SupplierViewModel(List<Supplier> s)
        {
            Data = new ObservableCollection<Supplier>(s);
        }
    }
}