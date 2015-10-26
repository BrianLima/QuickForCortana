using QuickForCortana.Models;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace QuickForCortana
{
    public sealed partial class NoteDetailPage : Page
    {
        public NoteDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var note = ((NoteControl)e.Parameter).DataContext;

            base.OnNavigatedTo(e);

            NoteGrid.DataContext = note;

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                // If we have pages in our in-app backstack and have opted in to showing back, do so
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if there are no pages in our in-app back stack
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            //TODO:Save Note
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            //TODO:Cancel and navigate to previous page
        }
    }
}