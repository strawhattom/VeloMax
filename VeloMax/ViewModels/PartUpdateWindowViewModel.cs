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
        private string? _id;
        private string? _description;
        private string? _price;
        private string? _delay;
        private string? _quantity;
        private string? _type;
        private string? _data;
        private DateTimeOffset _introduction = DateTime.Now;
        private DateTimeOffset _discontinuation = DateTime.Now;
        private Database _db = new Database();
        private bool _closeAppTrigger;

        public string? IdText
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }
        public string? DescriptionText
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }
        public string? PriceText
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
        }
        public string? DelayText
        {
            get => _delay;
            set => this.RaiseAndSetIfChanged(ref _delay, value);
        }
        public string? QuantityText
        {
            get => _quantity;
            set => this.RaiseAndSetIfChanged(ref _quantity, value);
        }
        public string? TypeText
        {
            get => _type;
            set => this.RaiseAndSetIfChanged(ref _type, value);
        }
        public string? DataText
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
            if (!(selected == null))
            {
                _current = selected;
                IdText = _current.at(0);
                DescriptionText = _current.at(1).Trim('\'');
                PriceText = _current.at(2);
                DelayText = _current.at(3);

                string[] idt = _current.at(4).Trim('\'').Split('-');
                IntroductionDT = new DateTimeOffset(new DateTime(Int32.Parse(idt[0]), Int32.Parse(idt[1]), Int32.Parse(idt[2])));
                string[] ddt = _current.at(5).Trim('\'').Split('-');
                DiscontinuationDT = new DateTimeOffset(new DateTime(Int32.Parse(idt[0]), Int32.Parse(idt[1]), Int32.Parse(idt[2])));

                DelayText = _current.at(6);
                QuantityText = _current.at(7);
                TypeText = _current.at(8).Trim('\'');
            }
            

            UpdateClick = ReactiveCommand.Create(OnUpdateClick);
            CloseButtonClicked = ReactiveCommand.Create(() => { CloseAppTrigger = true; });
        }

        private void OnUpdateClick()
        {
            DataText = IdText + " " + DescriptionText + " " + PriceText + " " + DelayText + " " + QuantityText + " " + TypeText + "\n" +
                            "Introduction : " + IntroductionDT.ToString() +
                            "\n Discontinuation : " + DiscontinuationDT.ToString();
            Console.WriteLine("Form data : ");
            Console.Write(DataText + "\n");

            // Create our part
        }
    }
}
