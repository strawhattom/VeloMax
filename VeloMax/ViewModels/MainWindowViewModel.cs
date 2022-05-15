// using System;
using System.Windows.Input;
using System.Collections.Generic;
using VeloMax.Services;
using VeloMax.Models;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _navigationContent = new DashboardViewModel();
        // private string _searchText = "";
        public ICommand DashboardButtonClicked { get; }
        public ICommand BikePartButtonClicked { get; }
        public ICommand ClientButtonClicked { get; }
        public ICommand OrderButtonClicked { get; }
        public ICommand OtherButtonClicked { get; }
        public ICommand StockButtonClicked { get; }
        public ICommand SupplierButtonClicked { get; }

        
        // public ICommand SearchInput { get; }
        
        public ViewModelBase NavigationContent 
        { 
            get => this._navigationContent;
            set => this.RaiseAndSetIfChanged(ref this._navigationContent, value);
        }

        // public string SearchContent
        // {
        //     get => this._searchText;
        //     set => this.RaiseAndSetIfChanged(ref _searchText, value);
        // }

        // Constructor
        public MainWindowViewModel(Database db)
        {
            Db = db;
            DashboardButtonClicked = ReactiveCommand.Create(OnDashboardButtonClicked);
            BikePartButtonClicked = ReactiveCommand.Create(OnBikePartButtonClicked);
            ClientButtonClicked = ReactiveCommand.Create(OnClientButtonClicked);
            OrderButtonClicked = ReactiveCommand.Create(OnOrderButtonClicked);
            OtherButtonClicked = ReactiveCommand.Create(OnOtherButtonClicked);
            StockButtonClicked = ReactiveCommand.Create(OnStockButtonClicked);
            SupplierButtonClicked = ReactiveCommand.Create(OnSupplierButtonClicked);
        }

        private void OnDashboardButtonClicked()
        {
            this.NavigationContent = new DashboardViewModel();
        }

        private void OnBikePartButtonClicked()
        {
            this.NavigationContent = new BikePartViewModel(Db.GetParts());
        }

        private void OnClientButtonClicked()
        {
            this.NavigationContent = new ClientViewModel(Db.GetClients());
        }

        private void OnOrderButtonClicked()
        {
            this.NavigationContent = new OrderViewModel();
        }

        private void OnOtherButtonClicked()
        {
            this.NavigationContent = new OtherViewModel();
        }

        private void OnStockButtonClicked()
        {
            this.NavigationContent = new StockViewModel();
        }

        private void OnSupplierButtonClicked()
        {
            this.NavigationContent = new SupplierViewModel();
        }

    }
}
