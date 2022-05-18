using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using VeloMax.Models;
using VeloMax.Views;

namespace VeloMax.ViewModels
{
    public class SupplierViewModel : ViewModelBase
    {
        public ObservableCollection<object> Suppliers { get; set; }
        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> Update { get; }
        public ReactiveCommand<Unit, Unit> Delete { get; }
        private Supplier _selectObj;
        public SupplierViewModel(List<Supplier> s)
        {
            Suppliers = new ObservableCollection<object>(s);
            Add = ReactiveCommand.Create(() =>
            {
                var update = new SupplierUpdateWindow
                {
                    DataContext = new SupplierUpdateWindowViewModel(Suppliers),
                };
                update.Show();
            });
            Update = ReactiveCommand.Create(() =>
            {
                var update = new SupplierUpdateWindow
                {
                    DataContext = new SupplierUpdateWindowViewModel(Suppliers, _selectObj),
                };
                update.Show();
            });
            Delete = ReactiveCommand.Create(() =>
            {
                var messageBox = new Message
                {
                    DataContext = new MessageWindowViewModel(Suppliers, _selectObj),
                };
                messageBox.Show();
            });
        }
        public Supplier SelectedSupplier
        {
            get => _selectObj;
            set => this.RaiseAndSetIfChanged(ref _selectObj, value);
        }
    }
}
