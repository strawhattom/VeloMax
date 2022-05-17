using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using VeloMax.Models;
using VeloMax.Views;

namespace VeloMax.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        public ObservableCollection<Part> Parts { get; set; } // don't change it
        public object _selectedPart = new object();

        public int _idSelected;

        public Part SelectedPart
        {
            get => (Part)_selectedPart;
            set => this.RaiseAndSetIfChanged(ref _selectedPart, value);
        }
        public ICommand UpdateClicked { get; set; }
        public ICommand ModifyClicked { get; set; }
        public PartViewModel(List<Part> p)
        {
            Parts = new ObservableCollection<Part>(p); 
            _selectedPart = Parts[0];
            UpdateClicked = ReactiveCommand.Create(OnUpdateClick);
            ModifyClicked = ReactiveCommand.Create(OnModifyClick);
            
        }

        private void OnModifyClick()
        {
            Console.WriteLine("Want to modify");
            var edit = new EditWindow();
            edit.Show();
        }

        private void OnUpdateClick()
        {
            Console.WriteLine(SelectedPart.ToString());
        }

        private void CellClick(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(e);
        }
    }
}
