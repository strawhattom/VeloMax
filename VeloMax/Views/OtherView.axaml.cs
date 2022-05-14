using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VeloMax.Views
{
    public partial class OtherView : UserControl
    {
        public OtherView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}