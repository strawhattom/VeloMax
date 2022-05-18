using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using System.Linq;
using VeloMax.Services;
using VeloMax.Models;
using ReactiveUI;


namespace VeloMax.ViewModels
{
    public class MessageWindowViewModel : ReactiveObject
    {
        private string _message = "Are you sure ?";
        private string _action = "none";
        private Database _db = new Database();

        public string Action
        {
            get => _action;
            set => this.RaiseAndSetIfChanged(ref _action, value);
        }
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public ICommand ConfirmClick { get; }
        public ICommand CancelClick { get; }
        public MessageWindowViewModel(ObservableCollection<object> items, object o)
        {
            var item = o;
            ConfirmClick = ReactiveCommand.Create(() =>
            {
                Action = "CONFIRM";
                var find = items.FirstOrDefault(i => ReferenceEquals(o, i));
                if (find != null)
                {
                    switch (o)
                    {
                        case Part p:
                            _db.DeleteParts((Part)find);
                            items.Remove(find);
                            break;
                        case Bike b:
                            _db.DeleteBikes((Bike)find);
                            items.Remove(find);
                            break;

                        case Supplier s:
                            _db.DeleteSuppliers((Supplier)find);
                            items.Remove(find);
                            break;

                        case Client c:
                            _db.DeleteClient((Client)find);
                            items.Remove(find);
                            break;
                    }
                }
                else
                {
                    Debug.WriteLine("ERROR : item not in collection");
                }
                

                Debug.WriteLine(_action);
            });
            CancelClick = ReactiveCommand.Create(() =>
            {
                Action = "CANCEL";
                Debug.WriteLine(_action);
            });
        }
    }
}