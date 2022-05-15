using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        public ObservableCollection<Client> Clients { get; }
        public ClientViewModel(List<Client> clients)
        {
            Clients = new ObservableCollection<Client>(clients);
        }
    }
}
