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
    public class SupplierUpdateWindowViewModel : ReactiveObject
    {
        private Supplier? _current;
        private string _mode = "ADD";
        private int _id;
        private string _name = "";
        private string _siret = "";
        private string _contact = "";
        private string _location = "";
        private string _label = "";
        private string _data = "";
        private string _color = "black";
        private ObservableCollection<object> _obj;
        private readonly Database _db = new();
        private bool _closeAppTrigger = false;

        public string NameText
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        public string SiretText
        {
            get => _siret;
            set => this.RaiseAndSetIfChanged(ref _siret, value);
        }
        public string ContactText
        {
            get => _contact;
            set => this.RaiseAndSetIfChanged(ref _contact, value);
        }
        public string LocationText
        {
            get => _location;
            set => this.RaiseAndSetIfChanged(ref _location, value);
        }

        public string LabelText
        {
            get => _label;
            set => this.RaiseAndSetIfChanged(ref _label, value);
        }
        public string DataText
        {
            get => _data;
            set => this.RaiseAndSetIfChanged(ref _data, value);
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
        public SupplierUpdateWindowViewModel(ObservableCollection<object> obj)
        {
            _obj = obj;
            _current = new Supplier();
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }
        public SupplierUpdateWindowViewModel(ObservableCollection<object> obj, Supplier selected)
        {
            _obj = obj;
            
            
            if (!(selected == null))
            {
                _mode = "UPDATE";
                _current = selected;
                _id = selected.Id;
                NameText = selected.Name;
                SiretText = selected.Siret;
                ContactText = selected.Contact;
                LocationText = selected.Location;
                LabelText = selected.Label;
            }
            
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }

        private void OnUpdateClick()
        {
            // Create our part
            if (NameText != "" && NameText.Length > 0
                && SiretText != "" && SiretText.Length > 0
                && ContactText != "" && ContactText.Length > 0
                && LocationText != "" && LocationText.Length > 0
                && LabelText != "" && LabelText.Length > 0)
            {
                int idField = (_mode == "ADD") ? _db.GetMaxID(Supplier.TypeC()) : _id;
                try
                {
                    _current.Id = idField;
                    _current.Name = NameText;
                    _current.Siret = SiretText;
                    _current.Contact = ContactText;
                    _current.Location = LocationText;
                    if (Int32.Parse(LabelText) > 5 || Int32.Parse(LabelText) < 1)
                    {
                        throw new FormatException();
                    }
                    _current.Label= LabelText;

                    Debug.WriteLine(NameText + " " + SiretText + " " + ContactText + " " + LocationText + " " + LabelText);


                    _db.SetSuppliers(_current);
                    
                    // Updating Datagrid
                    if (_mode == "ADD")
                    {
                        _obj.Add(_current);
                    }
                    else
                    {
                        _obj = new ObservableCollection<object>(_db.GetSuppliers());
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