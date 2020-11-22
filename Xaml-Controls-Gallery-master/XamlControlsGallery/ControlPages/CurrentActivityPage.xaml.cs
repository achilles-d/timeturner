//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
using Windows.Storage;

namespace AppUIBasics.ControlPages
{
    public sealed partial class CurrentActivityPage : Page
    {
        public CurrentActivityPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Parse info for new and old activity
            base.OnNavigatedTo(e);
            string activitySaveFilename = "activitySave" + e.Parameter + ".txt";
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile activitySaveFile = await localFolder.CreateFileAsync(activitySaveFilename, CreationCollisionOption.OpenIfExists);
            string newActivity = await FileIO.ReadTextAsync(activitySaveFile);

            StorageFile oldActivityFile = await localFolder.CreateFileAsync("currentActivity.txt", CreationCollisionOption.OpenIfExists);
            string oldActivityString = await FileIO.ReadTextAsync(oldActivityFile);
            string[] oldActivityInfo = oldActivityString.Split("|");

            // Write current activity info to a file for persistence
            StorageFile currentActivityFile = await localFolder.CreateFileAsync("currentActivity.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(currentActivityFile, newActivity + "|" + e.Parameter);

            // Display current activity
            TextBlock currentActivityTextBlock = this.FindName("NewActivity") as TextBlock;
            TextBlock activityNumberTextBlock = this.FindName("NewActivityNumber") as TextBlock;
            if (newActivity.Equals("") || newActivity.Equals("\r"))
                currentActivityTextBlock.Text = "Not set";
            else
                currentActivityTextBlock.Text = newActivity;
            activityNumberTextBlock.Text = e.Parameter + ":";

            TextBlock oldActivityTextBlock = this.FindName("OldActivity") as TextBlock;
            TextBlock oldActivityNumberTextBlock = this.FindName("OldActivityNumber") as TextBlock;
            if (oldActivityInfo[0].Equals("") || oldActivityInfo[0].Equals("\r"))
                oldActivityTextBlock.Text = "Not set";
            else
                oldActivityTextBlock.Text = oldActivityInfo[0];
            oldActivityNumberTextBlock.Text = oldActivityInfo[1] + ":";

            // Briefly block current thread before returning to previous page
            await Task.Delay(3000);
            this.Frame.GoBack();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
