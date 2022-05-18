using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VeloMax.Models;

namespace VeloMax.Views
{
    public partial class Message : Window
    {
        public Message()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}