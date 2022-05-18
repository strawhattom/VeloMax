using System.Windows.Input;
using System.Diagnostics;
using VeloMax.Models;
using ReactiveUI;


namespace VeloMax.ViewModels
{
    public class MessageWindowViewModel : ReactiveObject
    {
        private string _message = "Default message";
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
        public MessageWindowViewModel(string message)
        {
            ConfirmClick = ReactiveCommand.Create(() =>
            {
                _action = "CONFIRM";
                Debug.WriteLine(_action);
            });
            CancelClick = ReactiveCommand.Create(() =>
            {
                _action = "CANCEL";
                Debug.WriteLine(_action);
            });
        }
    }
}