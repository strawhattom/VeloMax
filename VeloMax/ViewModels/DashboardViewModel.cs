using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Services;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private List<List<string>> _customersFidelityData = new();
        private ObservableCollection<List<string>> _emptyPart = new();
        private List<List<string>> _worstSuppliers = new();
        private string _avgOrderPrice, _avgOrderQty, _avgBikeSold; // this order : mean(order_price), mean(order_quantity), mean(bike_sold)
        private List<List<string>> _bestCustomers = new();
        private List<List<string>> _customersExpirationDate = new();

        public string BikeName { get; set; }
        public string BikeSum { get; set; }
        public string BikeQty { get; set; }
        public string BikeAvg { get; set; }
        public string PartName{ get; set; }
        public string PartSum { get; set; }
        public string PartQty { get; set; }
        public string PartAvg { get; set; }
        public string AvgOrderPrice{ get; set; }
        public string AvgOrderQty { get; set; }
        public string AvgBikeSold { get; set; }
        public ObservableCollection<string> WorstSuppliers { get; set; }


        public DashboardViewModel(Database db)
        {
            
            this.InitBestBike(db);
            this.InitAverageData(db);
            this.InitBestPart(db);
            
        }
        public void InitAverageData(Database db)
        {
            var averageData = db.Average();
            if (averageData.Count == 0)
            {
                AvgBikeSold = "0";
                AvgOrderPrice = "0";
                AvgOrderQty = "0";
            }
            else
            {
                AvgOrderPrice = "Price : " + averageData[0];
                AvgOrderQty = "Quantity : " + averageData[1];
                AvgBikeSold = "Sold : " + averageData[2];
            }
        }
        public void InitBestPart(Database db)
        {
            var bestPart = db.BestPart();
            if (bestPart.Count == 0)
            {
                PartName = "None";
                PartQty = "None";
                PartSum = "None";
                PartAvg = "None";
            }
            else
            {
                PartName = bestPart[0];
                PartQty = "Quantity sold : " + bestPart[1];
                PartSum = "Total gained : " + bestPart[2];
                PartAvg = "Average per sold : " + bestPart[3].Split(',')[0]; // get int part
            }
        }
        public void InitBestBike(Database db)
        {
            var bestBike = db.BestBike();
            if (bestBike.Count == 0)
            {
                BikeName = "None";
                BikeQty = "None";
                BikeSum = "None";
                BikeAvg = "None";
            }
            else
            {
                BikeName = bestBike[0];
                BikeQty = "Quantity sold : " + bestBike[1];
                BikeSum = "Total gained : " + bestBike[2];
                BikeAvg = "Average per sold : " + bestBike[3].Split(',')[0]; // get int part
            }
        }
        public void InitBestClient(Database db)
        {
            var client = db.BestClients();
        }
        public void InitWorstSuppliers(Database db)
        {
            var worst = db.WorstSuppliers();
            WorstSuppliers = new ObservableCollection<string>(worst);
        }
    }
}
