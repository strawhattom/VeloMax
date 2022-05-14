using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VeloMax.Views
{
    public partial class BikePartView : UserControl
    {
        public BikePartView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}