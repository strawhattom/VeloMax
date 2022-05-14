using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VeloMax.Views
{
    public partial class ClientView : UserControl
    {
        public ClientView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}