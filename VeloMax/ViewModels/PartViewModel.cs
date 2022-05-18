using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using VeloMax.Models;
using VeloMax.Services;
using VeloMax.Views;

namespace VeloMax.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        public ObservableCollection<object> Parts { get; set; } // don't change it
        public ReactiveCommand<Unit, Unit> AddPart { get; }
        public ReactiveCommand<Unit, Unit> UpdatePart { get; }
        public ReactiveCommand<Unit, Unit> DeletePart { get; }
        
        public ReactiveCommand<Unit, Unit> SaveJson { get;  }

        private Part _selectPart;
        private string _searchText;
        
        public PartViewModel(List<Part> p, Database DB)
        {
            Parts = new ObservableCollection<object>(p);
            AddPart = ReactiveCommand.Create(() =>
            {
                var update = new PartUpdateWindow
                {
                    DataContext = new PartUpdateWindowViewModel(Parts),
                };
                update.Show();
            });
            UpdatePart = ReactiveCommand.Create(() =>
            {
                var update = new PartUpdateWindow
                {
                    DataContext = new PartUpdateWindowViewModel(Parts, _selectPart),
                };
                update.Show();
            });
            DeletePart = ReactiveCommand.Create(() =>
            {
                var messageBox = new Message
                {
                    DataContext = new MessageWindowViewModel(Parts, _selectPart),
                };
                messageBox.Show();
            });
            SaveJson = ReactiveCommand.Create(  () =>
            {
                var export = new JsonExportWindow
                {
                    DataContext = new JsonExportWindowViewModel()
                };
                export.Show();
            });
            
            
        }

        public Part SelectedPart
        {
            get => _selectPart;
            set => this.RaiseAndSetIfChanged(ref _selectPart, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

    }
}