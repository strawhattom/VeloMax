using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using VeloMax.Models;
using VeloMax.Views;

namespace VeloMax.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        private string _type = "Client";
        private ObservableCollection<Object> _data;
        private Client _selectObj;

        public string Type
        {
            get => _type;
            set => this.RaiseAndSetIfChanged(ref _type, value);
        }

        public ObservableCollection<object> ClientData // don't change it
        {
            get => _data;
            set => this.RaiseAndSetIfChanged(ref _data, value);
        }

        public Client SelectedClient
        {
            get => _selectObj;
            set => this.RaiseAndSetIfChanged(ref _selectObj, value);
        }
        public ReactiveCommand<Unit, Unit> AddIndividual { get; }
        public ReactiveCommand<Unit, Unit> AddProfessional { get; }
        public ReactiveCommand<Unit, Unit> Update { get; }
        public ReactiveCommand<Unit, Unit> Delete { get; }

        public ClientViewModel(List<Client> c)
        {
            //Default properties
            ClientData = new ObservableCollection<object>(c);

            AddIndividual = ReactiveCommand.Create(() => 
            {
                var update = new IndividualUpdateWindow
                {
                    DataContext = new IndividualUpdateWindowViewModel(ClientData),
                };
                update.Show();
            });
            AddProfessional = ReactiveCommand.Create(() => 
            {
                var update = new ProfessionalUpdateWindow
                {
                    DataContext = new ProfessionalUpdateWindowViewModel(ClientData),
                };
                update.Show();
            });
            Update = ReactiveCommand.Create(() =>
            {
                if (_selectObj is Professional)
                {
                    var update = new ProfessionalUpdateWindow
                    {
                        DataContext = new ProfessionalUpdateWindowViewModel(ClientData, (Professional)_selectObj),
                    };
                    update.Show();
                }
                else
                {
                    var update = new IndividualUpdateWindow
                    {
                        DataContext = new IndividualUpdateWindowViewModel(ClientData, (Individual)_selectObj),
                    };
                    update.Show();
                }
            });
            Delete = ReactiveCommand.Create(() =>
            {
                var messageBox = new Message
                {
                    DataContext = new MessageWindowViewModel(ClientData, _selectObj),
                };
                messageBox.Show();
            });
        }
    }
}