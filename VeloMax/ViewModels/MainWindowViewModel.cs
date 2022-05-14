﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _navigationContent = new DashboardViewModel();
        public ICommand DashboardClicked { get; }

        public ICommand BikePartClicked { get; }

        public ICommand ClientClicked { get; }

        public ICommand OrderClicked { get; }

        public ICommand OtherClicked { get; }

        public ICommand SupplierClicked { get; }

        public ICommand StockClicked { get; }

        public ViewModelBase NavigationContent
        {
            get => this._navigationContent;
            set => this.RaiseAndSetIfChanged(ref this._navigationContent, value);
        }

        public MainWindowViewModel()
        {
            this.DashboardClicked = ReactiveCommand.Create(this.OnDashboardClicked);
            this.BikePartClicked = ReactiveCommand.Create(this.OnBikePartClicked);
            this.ClientClicked = ReactiveCommand.Create(this.OnClientClicked);
            this.OrderClicked = ReactiveCommand.Create(this.OnOrderClicked);
            this.OtherClicked = ReactiveCommand.Create(this.OnOtherClicked);
            this.StockClicked = ReactiveCommand.Create(this.OnStockClicked);
            this.SupplierClicked = ReactiveCommand.Create(this.OnSupplierClicked);
        }

        private void OnDashboardClicked()
        {
            this.NavigationContent = new DashboardViewModel();
        }

        private void OnBikePartClicked()
        {
            this.NavigationContent = new BikePartViewModel();
        }

        private void OnClientClicked()
        {
            this.NavigationContent = new ClientViewModel();
        }

        private void OnOrderClicked()
        {
            this.NavigationContent = new OrderViewModel();
        }

        private void OnOtherClicked()
        {
            this.NavigationContent = new OtherViewModel();
        }

        private void OnStockClicked()
        {
            this.NavigationContent = new StockViewModel();
        }

        private void OnSupplierClicked()
        {
            this.NavigationContent = new SupplierViewModel();
        }
    }
}
