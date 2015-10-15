using QuickForCortana.Models;
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