using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using VeloMax.Models;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        private string _type = "Client";
        private ObservableCollection<Object> _data = new();
        private Object _selected = new();
        public ICommand ClientButtonClick { get; }
        public ICommand IndividualButtonClick { get; }
        public ICommand ProfessionalButtonClick { get; }
        public ObservableCollection<Object> Clients { get; }
        public ObservableCollection<Object> Individuals { get; }
        public ObservableCollection<Object> Professionals { get; }

        public string Type
        {
            get => _type;
            set => this.RaiseAndSetIfChanged(ref _type, value);
        }

        public ObservableCollection<Object> ClientData // don't change it
        {
            get => _data;
            set => this.RaiseAndSetIfChanged(ref _data, value);
        }

        public Object Selected
        {
            get => _selected;
            set => this.RaiseAndSetIfChanged(ref _selected, value);
        }

        public ClientViewModel(List<Client> c, List<Individual> i, List<Professional> p)
        {
            Clients = new ObservableCollection<Object>(c);
            Individuals = new ObservableCollection<Object>(i);
            Professionals = new ObservableCollection<Object>(p);

            //Default properties
            ClientData = Clients;
            Type = "Client";

            ClientButtonClick = ReactiveCommand.Create(ClientShowClicked);
            IndividualButtonClick = ReactiveCommand.Create(IndividualShowClicked);
            ProfessionalButtonClick = ReactiveCommand.Create(ProfessionalShowClicked);
        }

        public void ClientShowClicked()
        {
            Type = "Client";
            ClientData = Clients;
        }

        public void IndividualShowClicked()
        {
            Type = "Individual";
            ClientData = Individuals;
        }

        public void ProfessionalShowClicked()
        {
            Type = "Professionnal";
            ClientData = Professionals;
        }
    }
}