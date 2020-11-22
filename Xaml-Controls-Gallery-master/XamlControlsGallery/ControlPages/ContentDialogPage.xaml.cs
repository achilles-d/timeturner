using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace AppUIBasics.ControlPages
{
    public sealed partial class ContentDialogPage : Page
    {
        public ContentDialogPage()
        {
            this.InitializeComponent();
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Parse info for activity that has started
            base.OnNavigatedTo(e);
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile currentActivityFile = await localFolder.CreateFileAsync("currentActivity.txt", CreationCollisionOption.OpenIfExists);
            string activityInfoString = await FileIO.ReadTextAsync(currentActivityFile);
            string[] activityInfo = activityInfoString.Split("|");
            // Display current activity
            TextBlock currentActivityTextBlock = this.FindName("CurrentActivity") as TextBlock;
            if (activityInfo[0].Equals("") || activityInfo[0].Equals("\r"))
                activityInfo[0] = "[Not set]";
            currentActivityTextBlock.Text = activityInfo[0] + " (Face #" + activityInfo[1] + ")";
        }
    }
}

