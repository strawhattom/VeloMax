using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VeloMax.Views
{
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}