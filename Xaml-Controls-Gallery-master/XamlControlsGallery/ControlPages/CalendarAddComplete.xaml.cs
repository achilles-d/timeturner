
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppUIBasics.ControlPages
{
    public sealed partial class CalendarAddComplete : Page
    {
        public CalendarAddComplete()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await Task.Delay(1800);
            this.Frame.Navigate(typeof(ControlPages.ProgressBarPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

