using System;
using System.Diagnostics;
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
        private Part? _selected;
        public ObservableCollection<Part> Parts { get; set; } // don't change it
        public ICommand ModifyClicked { get; set; }
        public Part? ItemSelected { 
            get => _selected; 
            set => this.RaiseAndSetIfChanged(ref _selected, value); 
        }
        public PartViewModel(List<Part> p)
        {
            Parts = new ObservableCollection<Part>(p);
            ModifyClicked = ReactiveCommand.Create(OnModifyClick);
        }
        private void OnModifyClick()
        {
            Debug.WriteLine("Want to update");
            var update = new PartUpdateWindow
            {
                DataContext = new PartUpdateWindowViewModel(ItemSelected),
            };
            update.Show();
        }
    }
}