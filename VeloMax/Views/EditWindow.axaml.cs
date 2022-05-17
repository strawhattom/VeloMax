using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VeloMax.Models;

namespace VeloMax.Views
{
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(object o)
        {
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}