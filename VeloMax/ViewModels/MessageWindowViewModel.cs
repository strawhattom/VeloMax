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
        private object _object;

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
            _object = o;
            ConfirmClick = ReactiveCommand.Create(OnConfirmClick);
            CancelClick = ReactiveCommand.Create(OnCancelClick);
        }

        public void OnConfirmClick()
        {
            Action = "CONFIRM";
            Debug.WriteLine(_action);
        }

        public void OnCancelClick()
        {
            Action = "CANCEL";
            Debug.WriteLine(_action);
        }
    }
}