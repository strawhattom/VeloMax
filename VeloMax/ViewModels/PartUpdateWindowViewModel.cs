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
        private int _id;
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
                _id = selected.Id;
                DescriptionText = selected.Description;
                PriceText = selected.At(2);

                string[] idt = selected.At(3).Trim('\'').Split('-');
                IntroductionDT = new DateTimeOffset(new DateTime(Int32.Parse(idt[0]), Int32.Parse(idt[1]), Int32.Parse(idt[2])));
                string[] ddt = selected.At(4).Trim('\'').Split('-');
                DiscontinuationDT = new DateTimeOffset(new DateTime(Int32.Parse(ddt[0]), Int32.Parse(ddt[1]), Int32.Parse(ddt[2])));

                DelayText = selected.At(5);
                QuantityText = selected.At(6);
                TypeText = selected.Type;
            }
            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }

        private void OnUpdateClick()
        {
            // Create our part
            if (DescriptionText != "" && DescriptionText.Length > 0
                && PriceText != "" && PriceText.Length > 0
                && DelayText != "" && DelayText.Length > 0
                && QuantityText != "" && QuantityText.Length > 0
                && TypeText != "" && TypeText.Length > 0)
            {
                int idField = (_mode == "ADD") ? _db.GetMaxID(Part.TypeC()) : _id;
                try
                {
                    _db.SetParts(new Part(
                        idField,
                        DescriptionText,
                        Double.Parse(PriceText),
                        IntroductionDT.DateTime,
                        DiscontinuationDT.DateTime,
                        Int32.Parse(DelayText),
                        Int32.Parse(QuantityText),
                        TypeText)
                    );

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
