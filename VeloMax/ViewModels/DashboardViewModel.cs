using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Services;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private List<string> _bestPart;
        private List<string> _bestBike;
        private string _bikeName, _bikeSum, _bikeQty, _bikeAvg;
        private List<List<string>> _customersFidelityData = new();
        private ObservableCollection<List<string>> _emptyPart = new();
        private List<List<string>> _worstSuppliers = new();
        private List<int> _averageData; // this order : mean(order_price), mean(order_quantity), mean(bike_sold)
        private string _avgOrderPrice, _avgOrderQty, _avgBikeSold;
        private List<List<string>> _bestCustomers = new();
        private List<List<string>> _customersExpirationDate = new();

        public string BikeName 
        {
            get => _bikeName;
            set => this.RaiseAndSetIfChanged(ref _bikeName, value);
        }
        public string BikeSum
        {
            get => _bikeSum;
            set => this.RaiseAndSetIfChanged(ref _bikeSum, value);
        }
        public string BikeQty
        {
            get => _bikeQty;
            set => this.RaiseAndSetIfChanged(ref _bikeQty, value);
        }
        public string BikeAvg
        {
            get => _bikeAvg;
            set => this.RaiseAndSetIfChanged(ref _bikeAvg, value);
        }
        public string AvgOrderPrice
        {
            get => _avgOrderPrice;
            set => this.RaiseAndSetIfChanged(ref _avgOrderPrice, value);
        }
        public string AvgOrderQty
        {
            get => _avgOrderQty;
            set => this.RaiseAndSetIfChanged(ref _avgOrderQty, value);
        }
        public string AvgBikeSold
        {
            get => _avgBikeSold;
            set => this.RaiseAndSetIfChanged(ref _avgBikeSold, value);
        }

        public DashboardViewModel(Database db)
        {
            _bestPart = db.BestPart();
            _bestBike = db.BestBike();
            _averageData = db.Average();

            if (_bestBike.Count == 0)
            {
                BikeName = "None";
                BikeQty = "None";
                BikeSum = "None";
                BikeAvg = "None";
            } else
            {
                BikeName = _bestBike[0];
                BikeQty = "Quantity sold : " + _bestBike[1];
                BikeSum = "Total gained : " + _bestBike[2];
                BikeAvg = "Average per sold : " + _bestBike[3].Split(',')[0]; // get int part
            }

            if (_averageData.Count == 0)
            {
                AvgBikeSold = "0";
                AvgOrderPrice = "0";
                AvgOrderQty = "0";
            } else
            {
                AvgOrderPrice = "Price : " + _averageData[0];
                AvgOrderQty = "Quantity : " + _averageData[1];
                AvgBikeSold = "Sold : " + _averageData[2];
            }
            
        }
        
    }
}
