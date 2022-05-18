using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;
using VeloMax.Models;
using VeloMax.Views;

namespace VeloMax.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        private Part? _selected;
        public ObservableCollection<Part> Parts { get; set; } // don't change it
        public ICommand AddClicked { get; set; }
        public ICommand ModifyClicked { get; set; }
        public ICommand DeleteClicked { get; set; }

        public Part? ItemSelected
        {
            get => _selected;
            set => this.RaiseAndSetIfChanged(ref _selected, value);
        }
        public PartViewModel(List<Part> p)
        {

            Parts = new ObservableCollection<Part>(p);
            ModifyClicked = ReactiveCommand.Create(OnModifyClick);
            AddClicked = ReactiveCommand.Create(OnAddClick);
            DeleteClicked = ReactiveCommand.Create(OnDeleteClick);
        }

        private void OnAddClick()
        {
            Debug.WriteLine("Want to add");
            var update = new PartUpdateWindow
            {
                DataContext = new PartUpdateWindowViewModel(),
            };
            update.Show();
        }
        private void OnModifyClick()
        {
            Debug.WriteLine("Want to update");
            Debug.WriteLine(ItemSelected);
            var update = new PartUpdateWindow
            {
                DataContext = new PartUpdateWindowViewModel(ItemSelected),
            };
            update.Show();
        }

        private void OnDeleteClick()
        {
            var messageBox = new Message
            {
                DataContext = new MessageWindowViewModel("Voulez-vous vraiment cette pièce ?")
            };
            messageBox.Show();
        }
    }
}