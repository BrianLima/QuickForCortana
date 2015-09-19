using QuickStorage;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QuickForCortana
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            DataContext = new MainViewModel();

            // adicionando alguns dados falsos para teste
            ((MainViewModel)DataContext).Notes = new ObservableCollection<Note>
            {
                new Note { Content = "Nota 4", Date = DateTime.Today },
                new Note { Content = "Nota 27", Date = DateTime.Today },
                new Note { Content = "Nota 31", Date = DateTime.Today }
            };

            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            //Storage storage = new Storage();
            //await storage.deserializeJsonAsync(((MainViewModel)DataContext).Notes);
        }
    }


}
