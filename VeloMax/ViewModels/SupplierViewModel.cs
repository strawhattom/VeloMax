using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class SupplierViewModel : ViewModelBase
    {
        public ObservableCollection<Supplier> Suppliers { get; set; } // don't change it
        public SupplierViewModel(List<Supplier> s)
        {
            Suppliers = new ObservableCollection<Supplier>(s);
        }
    }
}