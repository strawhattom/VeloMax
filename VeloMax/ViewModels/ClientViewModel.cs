using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VeloMax.Models;

namespace VeloMax.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        public string Show = "Client";
        public ObservableCollection<Client> Clients { get; }
        public ObservableCollection<Individual> Individuals{ get; }
        public ObservableCollection<Professional> Professionals { get; }
        public ClientViewModel(List<Client> c, List<Individual> i, List<Professional> p)
        {
            Clients = new ObservableCollection<Client>(c);
            Individuals = new ObservableCollection<Individual>(i);
            Professionals = new ObservableCollection<Professional>(p);
        }

        public void ClientShowClick()
        {

        }

        public void IndividualShowClick()
        {

        }

        public void ProfessionalShowClick()
        {

        }
    }
}
