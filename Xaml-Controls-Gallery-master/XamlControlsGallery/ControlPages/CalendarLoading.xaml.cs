
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppUIBasics.ControlPages
{
    public sealed partial class CalendarLoading : Page
    {
        private bool _cancelButtonClicked = false;
        public CalendarLoading()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            _cancelButtonClicked = false;
            base.OnNavigatedTo(e);
            await Task.Delay(5000);
            if(!_cancelButtonClicked)
            {
                this.Frame.Navigate(typeof(ControlPages.CalendarAddComplete));
            }
            
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _cancelButtonClicked = true;
            this.Frame.Navigate(typeof(ControlPages.ProgressBarPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

