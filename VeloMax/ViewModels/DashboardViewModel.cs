using System;
using System.Collections.Generic;
using VeloMax.Services;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private List<string> _bestPart = new();
        private List<string> _bestBike = new();
        private List<List<string>> _customersFidelityData = new();
        private List<List<string>> _emptyPart = new();
        private List<List<string>> _worstSuppliers = new();
        private List<int> _averageData = new(); // this order : mean(order_price), mean(order_quantity), mean(bike_sold)
        private List<List<string>> _bestCustomers = new();
        private List<List<string>> _customersExpirationDate = new();

        public List<string> BestPart
        {
            get => _bestPart;
            set => this.RaiseAndSetIfChanged(ref _bestPart, value);
        }
        public List<string> BestBike
        {
            get => _bestBike;
            set => this.RaiseAndSetIfChanged(ref _bestBike, value);
        }

        public List<int> AverageData
        {
            get => _averageData;
            set => this.RaiseAndSetIfChanged(ref _averageData, value);
        }

        public DashboardViewModel(Database db)
        {
            BestPart = db.BestPart();
            BestBike = db.BestBike();
        }
        
    }
}
