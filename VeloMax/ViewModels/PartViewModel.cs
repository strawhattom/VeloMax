using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using VeloMax.Models;
using VeloMax.Views;

namespace VeloMax.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        public ObservableCollection<Part> Parts { get; set; } // don't change it
        public ReactiveCommand<Unit, Unit> AddPart { get; }
        public ReactiveCommand<Unit, Unit> UpdatePart { get; }
        public ReactiveCommand<Unit, Unit> DeletePart { get; }

        private Part _selectPart;
        
        public PartViewModel(List<Part> p)
        {
            Parts = new ObservableCollection<Part>(p);
            AddPart = ReactiveCommand.Create(() =>
            {
                var update = new PartUpdateWindow
                {
                    DataContext = new PartUpdateWindowViewModel(),
                };
                update.Show();
            });
            UpdatePart = ReactiveCommand.Create(() =>
            {
                var update = new PartUpdateWindow
                {
                    DataContext = new PartUpdateWindowViewModel(_selectPart),
                };
                update.Show();
            });
            DeletePart = ReactiveCommand.Create(OnDeleteClick);
        }

        public Part SelectedPart
        {
            get => _selectPart;
            set => this.RaiseAndSetIfChanged(ref _selectPart, value);
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
            var update = new PartUpdateWindow
            {
                DataContext = new PartUpdateWindowViewModel(),
            };
            update.Show();
        }

        private void OnDeleteClick()
        {
            var messageBox = new Message
            {
                DataContext = new MessageWindowViewModel(ItemSelected),
            };
            messageBox.Show();
        }
    }
}