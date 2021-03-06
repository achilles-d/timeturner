
using System;
using System.IO;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppUIBasics.ControlPages
{
    public sealed partial class CalendarInfoForm : Page
    {
        private readonly string CALENDAR_SAVE_FILE = "calendarEntrySaves.txt";
        private string _calendarService;
        public CalendarInfoForm()
        {
            _calendarService = null;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            _calendarService = (string)e.Parameter;
        }

        /*
         * Parse and serialize user email address and calendar service when "Sign In" is clicked
         */
        private async void SignIn_Click(object sender, RoutedEventArgs e)
        {
            TextBox emailTextBox = this.FindName("UsernameTextBox") as TextBox;
            string email = emailTextBox.Text;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile calendarSaveFile = await localFolder.CreateFileAsync(CALENDAR_SAVE_FILE, CreationCollisionOption.OpenIfExists);
            string calendarSave = email + "|" + _calendarService;
            await FileIO.AppendTextAsync(calendarSaveFile, calendarSave + "\n");

            this.Frame.Navigate(typeof(ControlPages.CalendarLoading));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ControlPages.ProgressBarPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

