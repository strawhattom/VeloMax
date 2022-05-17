using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using VeloMax.ViewModels;

namespace VeloMax.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }
        // Able to change panel
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            this.FindControl<Control>("Main").PointerPressed += (i, e) =>
            {
                PlatformImpl?.BeginMoveDrag(e);
            };
        }
    }
}