using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VeloMax.Views
{
    public partial class PartUpdateWindow: Window
    {
        public PartUpdateWindow()
        {

            InitializeComponent();
            DatePicker IntroductionDP = new DatePicker()
            {
                Header = "Introduction date"
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}