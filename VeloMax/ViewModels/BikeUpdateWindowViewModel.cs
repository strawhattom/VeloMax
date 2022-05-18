using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using VeloMax.Services;
using VeloMax.Models;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class BikeUpdateWindowViewModel : ReactiveObject
    {
        private Bike? _current;
        private string _mode = "ADD";
        private int _id;
        private string _name = "";
        private string _target = "";
        private string _price = "";
        private string _type = "";
        private string _data = "";
        private string _color = "black";
        private ObservableCollection<object> _obj;
        private DateTimeOffset _introduction = DateTime.Now;
        private DateTimeOffset _discontinuation = DateTime.Now;
        private readonly Database _db = new();
        private bool _closeAppTrigger = false;

        public string NameText
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        public string PriceText
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
        }
        public string TargetText
        {
            get => _target;
            set => this.RaiseAndSetIfChanged(ref _target, value);
        }
        public string TypeText
        {
            get => _type;
            set => this.RaiseAndSetIfChanged(ref _type, value);
        }
        public string DataText
        {
            get => _data;
            set => this.RaiseAndSetIfChanged(ref _data, value);
        }
        public DateTimeOffset IntroductionDT
        {
            get => _introduction;
            set => this.RaiseAndSetIfChanged(ref _introduction, value);
        }

        public DateTimeOffset DiscontinuationDT
        {
            get => _discontinuation;
            set => this.RaiseAndSetIfChanged(ref _discontinuation, value);
        }
        public bool CloseAppTrigger
        {
            get => this._closeAppTrigger;
            set => this.RaiseAndSetIfChanged(ref this._closeAppTrigger, value);
        }
        public string Color
        {
            get => _color;
            set => this.RaiseAndSetIfChanged(ref _color, value);
        }
        
        public ICommand CloseButtonClicked { get; }
        public ICommand UpdateClick { get; }
        public BikeUpdateWindowViewModel(ObservableCollection<object> obj)
        {
            _obj = obj;
            _current = new Bike();
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }
        public BikeUpdateWindowViewModel(ObservableCollection<object> obj, Bike selected)
        {
            _obj = obj;
            
            
            if (!(selected == null))
            {
                _mode = "UPDATE";
                _current = selected;
                _id = selected.Id;
                NameText = selected.Name;
                TargetText = selected.At(2).Trim('\'');
                PriceText = selected.At(3);
                TypeText = selected.Type;

                string[] idt = selected.At(5).Trim('\'').Split('-');
                IntroductionDT = new DateTimeOffset(new DateTime(Int32.Parse(idt[0]), Int32.Parse(idt[1]), Int32.Parse(idt[2])));
                string[] ddt = selected.At(6).Trim('\'').Split('-');
                foreach (var s in ddt)
                {
                    Debug.WriteLine(s);
                }
                DiscontinuationDT = new DateTimeOffset(new DateTime(Int32.Parse(ddt[0]), Int32.Parse(ddt[1]), Int32.Parse(ddt[2])));
            }
            
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }

        private void OnUpdateClick()
        {
            // Create our part
            if (NameText != "" && NameText.Length > 0
                && PriceText != "" && PriceText.Length > 0
                && TargetText != "" && TargetText.Length > 0
                && TypeText != "" && TypeText.Length > 0)
            {
                int idField = (_mode == "ADD") ? _db.GetMaxID(Bike.TypeC()) : _id;
                try
                {
                    _current.Id = idField;
                    _current.Name = NameText;
                    _current.Target = TargetText;
                    _current.UnitPrice = Double.Parse(PriceText);
                    _current.Type = TypeText;
                    _current.IntroductionDate = IntroductionDT.DateTime;
                    _current.DiscontinuationDate = DiscontinuationDT.DateTime;
                    
                    _db.SetBikes(_current);
                    
                    // Updating Datagrid
                    if (_mode == "ADD")
                    {
                        _obj.Add(_current);
                    }
                    else
                    {
                        _obj = new ObservableCollection<object>(_db.GetBikes());
                    }

                    Color = "#77DD77";
                    DataText = "Updated !";
                }
                catch (FormatException)
                {
                    Color = "#ff6961";
                    DataText = "Incorrect format in at least one field\nPlease verify fields";
                }
            }
            else
            {
                Color = "#ff6961";
                DataText = "Fill all fields please";
            }
        }

    }
}