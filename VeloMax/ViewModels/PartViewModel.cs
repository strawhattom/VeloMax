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
        private Part? _lastSelected;
        public ObservableCollection<Part> Parts { get; set; } // don't change it
        public ICommand AddClicked { get; set; }
        public ICommand ModifyClicked { get; set; }
        public Part? ItemSelected { 
            get => _selected;
            set => this.RaiseAndSetIfChanged(ref _selected, value); 
        }
        public PartViewModel(List<Part> p)
        {
            
            Parts = new ObservableCollection<Part>(p);
            _selected = Parts[2];
            ModifyClicked = ReactiveCommand.Create(OnModifyClick);
            AddClicked = ReactiveCommand.Create(OnAddClick);
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
    }
}