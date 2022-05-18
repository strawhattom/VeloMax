using System.Windows.Input;
using System.Diagnostics;
using VeloMax.Models;
using ReactiveUI;


namespace VeloMax.ViewModels
{
    public class MessageWindowViewModel : ReactiveObject
    {
        private string _message = "Are you sure ?";
        private string _action = "none";

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
        public MessageWindowViewModel(object o)
        {
            var item = o;
            ConfirmClick = ReactiveCommand.Create(() =>
            {
                Action = "CONFIRM";
                if (item is Part) { Debug.WriteLine("ITEM IS PART");  }
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