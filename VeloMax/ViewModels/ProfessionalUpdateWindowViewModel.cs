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
    public class ProfessionalUpdateWindowViewModel : ReactiveObject
    {
        private Professional? _current;
        private string _mode = "ADD";
        private int _id;
        private string _street = "";
        private string _city = "";
        private string _postalCode = "";
        private string _province = "";
        private string _phone = "";
        private string _mail = "";
        
        private string _companyName = "";
        private string _orderCount = "";
        private string _contactName = "";
        
        private string _data = "";
        
        private string _color = "black";
        private ObservableCollection<object> _obj;
        private readonly Database _db = new();
        private bool _closeAppTrigger = false;

        public string Street
        {
            get => _street;
            set => this.RaiseAndSetIfChanged(ref _street, value);
        }
        public string City
        {
            get => _city;
            set => this.RaiseAndSetIfChanged(ref _city, value);
        }
        public string Postal
        {
            get => _postalCode;
            set => this.RaiseAndSetIfChanged(ref _postalCode, value);
        }
        public string Province
        {
            get => _province;
            set => this.RaiseAndSetIfChanged(ref _province, value);
        }
        public string Phone
        {
            get => _phone;
            set => this.RaiseAndSetIfChanged(ref _phone, value);
        }
        public string Mail
        {
            get => _mail;
            set => this.RaiseAndSetIfChanged(ref _mail, value);
        }
        
        // For professionals
        public string Company
        {
            get => _companyName;
            set => this.RaiseAndSetIfChanged(ref _companyName, value);
        }
        
        public string OrderCount
        {
            get => _orderCount;
            set => this.RaiseAndSetIfChanged(ref _orderCount, value);
        }
        public string Contact
        {
            get => _contactName;
            set => this.RaiseAndSetIfChanged(ref _contactName, value);
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
        public ProfessionalUpdateWindowViewModel(ObservableCollection<object> obj)
        {
            _obj = obj;
            _current = new Professional();
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }
        public ProfessionalUpdateWindowViewModel(ObservableCollection<object> obj, Professional selected)
        {
            _obj = obj;
            
            
            if (!(selected == null))
            {
                _mode = "UPDATE";
                _current = selected;
                _id = selected.Id;
                Street = selected.Street;
                City = selected.City;
                Postal = selected.PostalCode;
                Province = selected.Province;
                Phone = selected.Phone;
                Mail = selected.Mail;
                Company = selected.CompanyName;
                OrderCount = selected.At(9);
                Contact = selected.ContactName;

            }
            
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }

        private void OnUpdateClick()
        {
            // Create our part
            if (Street != ""
                && City != ""
                && Postal != ""
                && Province != ""
                && Phone != ""
                && Mail != ""
                && Company != ""
                && OrderCount != ""
                && Contact != ""
                )
            {
                int idField = (_mode == "ADD") ? _db.GetMaxID("clients") : _id;
                try
                {
                    _current.Id = idField;
                    _current.Street = Street;
                    _current.City = City;
                    _current.PostalCode = Postal;
                    _current.Province = Province;
                    _current.Phone = Phone;
                    _current.Mail = Mail;
                    _current.CompanyName = Company;
                    _current.OrderCount = Int32.Parse(OrderCount);
                    _current.ContactName = Contact;

                    _db.SetClients(_current);
                    
                    // Updating Datagrid
                    if (_mode == "ADD")
                    {
                        _obj.Add(_current);
                    }
                    else
                    {
                        _obj = new ObservableCollection<object>(_db.GetClients());
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