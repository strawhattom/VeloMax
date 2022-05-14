// using System;
using System.Windows.Input;
// using Avalonia.Controls;
// using Avalonia.Input;
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
        public MainWindowViewModel()
        {
            this.DashboardButtonClicked = ReactiveCommand.Create(this.OnDashboardButtonClicked);
            this.BikePartButtonClicked = ReactiveCommand.Create(this.OnBikePartButtonClicked);
            this.ClientButtonClicked = ReactiveCommand.Create(this.OnClientButtonClicked);
            this.OrderButtonClicked = ReactiveCommand.Create(this.OnOrderButtonClicked);
            this.OtherButtonClicked = ReactiveCommand.Create(this.OnOtherButtonClicked);
            this.StockButtonClicked = ReactiveCommand.Create(this.OnStockButtonClicked);
            this.SupplierButtonClicked = ReactiveCommand.Create(this.OnSupplierButtonClicked);

        }

        private void OnDashboardButtonClicked()
        {
            this.NavigationContent = new DashboardViewModel();
        }

        private void OnBikePartButtonClicked()
        {
            this.NavigationContent = new BikePartViewModel();
        }

        private void OnClientButtonClicked()
        {
            this.NavigationContent = new ClientViewModel();
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
