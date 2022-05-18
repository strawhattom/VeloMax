using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Collections.ObjectModel;
using VeloMax.Services;
using VeloMax.Models;
using ReactiveUI;

namespace VeloMax.ViewModels
{
    public class PartUpdateWindowViewModel : ReactiveObject
    {
        private Part? _current;
        private string _mode = "ADD";
        private string _id = "";
        private string _description = "";
        private string _price = "";
        private string _delay = "";
        private string _quantity = "";
        private string _type = "";
        private string _data = "";
        private DateTimeOffset _introduction = DateTime.Now;
        private DateTimeOffset _discontinuation = DateTime.Now;
        private readonly Database _db = new();
        private bool _closeAppTrigger = false;

        public string IdText
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }
        public string DescriptionText
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }
        public string PriceText
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
        }
        public string DelayText
        {
            get => _delay;
            set => this.RaiseAndSetIfChanged(ref _delay, value);
        }
        public string QuantityText
        {
            get => _quantity;
            set => this.RaiseAndSetIfChanged(ref _quantity, value);
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
        public ICommand CloseButtonClicked { get; }
        public ICommand UpdateClick { get; }
        public PartUpdateWindowViewModel()
        {
            _current = null;
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }
        public PartUpdateWindowViewModel(Part selected)
        {
            _mode = "UPDATE";
            if (!(selected == null))
            {
                _current = selected;
                IdText = _current.At(0);
                DescriptionText = _current.At(1).Trim('\'');
                PriceText = _current.At(2);
                DelayText = _current.At(3);

                string[] idt = _current.At(4).Trim('\'').Split('-');
                IntroductionDT = new DateTimeOffset(new DateTime(Int32.Parse(idt[0]), Int32.Parse(idt[1]), Int32.Parse(idt[2])));
                string[] ddt = _current.At(5).Trim('\'').Split('-');
                DiscontinuationDT = new DateTimeOffset(new DateTime(Int32.Parse(idt[0]), Int32.Parse(idt[1]), Int32.Parse(idt[2])));

                DelayText = _current.At(6);
                QuantityText = _current.At(7);
                TypeText = _current.At(8).Trim('\'');
            }
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }

        private void OnUpdateClick()
        {
            // Create our part
            if (IdText != "" && IdText.Length > 0
                && DescriptionText != "" && DescriptionText.Length > 0
                && PriceText != "" && PriceText.Length > 0
                && DelayText != "" && DelayText.Length > 0
                && QuantityText != "" && QuantityText.Length > 0
                && TypeText != "" && TypeText.Length > 0)
            {
                int idField = (_mode == "ADD") ? _db.GetMaxID(Part.TypeC()) : Int32.Parse(IdText);
                try
                {
                    _db.SetParts(new Part(idField,
                    DescriptionText,
                    Double.Parse(PriceText),
                    IntroductionDT.DateTime,
                    DiscontinuationDT.DateTime,
                    Int32.Parse(DelayText),
                    Int32.Parse(QuantityText),
                    TypeText));

                    DataText = "Updated";
                }
                catch (FormatException)
                {
                    DataText = "Incorrect format in at least one field.\nPlease verify fields";
                }
            }

        }
    }
}
