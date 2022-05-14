using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VeloMax.Views
{
    public partial class StockView : UserControl
    {
        public StockView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}