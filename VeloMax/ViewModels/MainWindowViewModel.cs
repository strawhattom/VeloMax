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
        
        private bool _closeAppTrigger = false;

        private Database _db = new Database();
        // private string _searchText = "";
        private ViewModelBase _navigationContent = new();
        public ICommand DashboardButtonClicked { get; }
        public ICommand BikeButtonClicked { get; }
        public ICommand PartButtonClicked { get; }
        public ICommand ClientButtonClicked { get; }
        public ICommand OrderButtonClicked { get; }
        public ICommand OrderedButtonClicked { get; }
        public ICommand SettingButtonClicked { get; }
        public ICommand SupplierButtonClicked { get; }
        public ICommand CloseButtonClicked { get; }

        public ViewModelBase NavigationContent
        {
            get => this._navigationContent;
            set => this.RaiseAndSetIfChanged(ref this._navigationContent, value);
        }
        public bool CloseAppTrigger
        {
            get => this._closeAppTrigger;
            set => this.RaiseAndSetIfChanged(ref this._closeAppTrigger, value);
        }
        
        private string _searchText;
        
        // Constructor
        public MainWindowViewModel()
        {
            NavigationContent = new DashboardViewModel(_db);

            // Button
            DashboardButtonClicked = ReactiveCommand.Create(OnDashboardButtonClicked);
            BikeButtonClicked = ReactiveCommand.Create(OnBikeButtonClicked);
            PartButtonClicked = ReactiveCommand.Create(OnPartButtonClicked);
            ClientButtonClicked = ReactiveCommand.Create(OnClientButtonClicked);
            OrderButtonClicked = ReactiveCommand.Create(OnOrderButtonClicked);
            SettingButtonClicked = ReactiveCommand.Create(OnSettingButtonClicked);
            SupplierButtonClicked = ReactiveCommand.Create(OnSupplierButtonClicked);
            OrderedButtonClicked = ReactiveCommand.Create(OnOrderedButtonClicked);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });

        }


        private void OnDashboardButtonClicked()
        {
            this.NavigationContent = new DashboardViewModel(_db);
        }

        private void OnBikeButtonClicked()
        {
            this.NavigationContent = new BikeViewModel(_db.GetBikes(_searchText));
        }

        private void OnPartButtonClicked()
        {
            this.NavigationContent = new PartViewModel(_db.Search(_searchText), _db);
        }

        private void OnClientButtonClicked()
        {
            this.NavigationContent = new ClientViewModel(_db.GetClients(_searchText));
        }

        private void OnOrderButtonClicked()
        {
            this.NavigationContent = new OrderViewModel(_db.GetOrders());
        }
        private void OnOrderedButtonClicked()
        {
            this.NavigationContent = new OrderedViewModel(_db.GetOrderBikes(), _db.GetOrderParts());
        }

        private void OnSettingButtonClicked()
        {
            this.NavigationContent = new SettingViewModel();
        }

        private void OnSupplierButtonClicked()
        {
            this.NavigationContent = new SupplierViewModel(_db.GetSuppliers());
        }

        public string SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }
    }
}
