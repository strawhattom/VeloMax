using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using VeloMax.Models;
using VeloMax.Views;

namespace VeloMax.ViewModels
{
    public class BikeViewModel : ViewModelBase
    {
        public ObservableCollection<object> Bikes { get; set; }
        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> Update { get; }
        public ReactiveCommand<Unit, Unit> Delete { get; }
        private Bike _selectObj;
        public BikeViewModel(List<Bike> b)
        {
            Bikes = new ObservableCollection<object>(b);
            Add = ReactiveCommand.Create(() =>
            {
                var update = new BikeUpdateWindow
                {
                    DataContext = new BikeUpdateWindowViewModel(Bikes),
                };
                update.Show();
            });
            Update = ReactiveCommand.Create(() =>
            {
                var update = new BikeUpdateWindow
                {
                    DataContext = new BikeUpdateWindowViewModel(Bikes, _selectObj),
                };
                update.Show();
            });
            Delete = ReactiveCommand.Create(() =>
            {
                var messageBox = new Message
                {
                    DataContext = new MessageWindowViewModel(Bikes, _selectObj),
                };
                messageBox.Show();
            });
        }
        public Bike SelectedBike
        {
            get => _selectObj;
            set => this.RaiseAndSetIfChanged(ref _selectObj, value);
        }
    }
}
