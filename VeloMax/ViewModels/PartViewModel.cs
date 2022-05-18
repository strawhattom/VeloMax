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
        public ICommand ModifyClicked { get; set; }
        public PartViewModel(List<Part> p)
        {
            Parts = new ObservableCollection<Part>(p); 
            ModifyClicked = ReactiveCommand.Create(OnModifyClick);
        }
        private void OnModifyClick()
        {
            Console.WriteLine("Want to modify");
            var edit = new PartUpdateWindow();
            edit.Show();
        }
    }
}
