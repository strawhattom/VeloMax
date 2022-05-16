using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace VeloMax.Controls
{
    class ClientForm : DataGrid
    {
        public ClientForm()
        {

        }

        private void SelectHandler(object sender, SelectionChangedEventArgs e)
        {
            /*
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandardWindow("title", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed...");
            messageBoxStandardWindow.Show();
            */
        }
    }
}
