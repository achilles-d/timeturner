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
            base.OnNavigatedTo(e);
            string activitySaveFilename = "activitySave" + e.Parameter + ".txt";
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile activitySaveFile = await localFolder.CreateFileAsync(activitySaveFilename, CreationCollisionOption.OpenIfExists);
            string activity = await FileIO.ReadTextAsync(activitySaveFile);

            TextBlock currentActivityTextBlock = this.FindName("CurrentActivityTextBlock") as TextBlock;
            TextBlock activityNumberTextBlock = this.FindName("ActivityNumber") as TextBlock;
            //currentActivityTextBlock.Text = e.Parameter.ToString();
            if (activity.Equals("") || activity.Equals("\r"))
                currentActivityTextBlock.Text = "Not set";
            else
                currentActivityTextBlock.Text = activity;
            activityNumberTextBlock.Text = "Activity " + e.Parameter + ":";
            
            await Task.Delay(2000);
            this.Frame.GoBack();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
