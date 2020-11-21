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
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppUIBasics.ControlPages
{
    public sealed partial class HyperlinkButtonPage : Page
    {
        public readonly string ACTIVITY_TEXTBOX_PREFIX = "Activity";
        public readonly string ACTIVITY_SAVE_PREFIX = "activitySave";
        public readonly string ACTIVITY_SAVE_SUFFIX = ".txt";
        public readonly string NO_ACTIVITY_MESSAGE = "Not set";
        public readonly string ACTIVITY_MESSAGE_PREFIX = "Current activity: ";
        private NavigationEventArgs _pastNavigationEventArgs;
        public HyperlinkButtonPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _pastNavigationEventArgs = e;
            for (int i = 1; i <= 12; i++)
            {
                string activitySaveFilename = ACTIVITY_SAVE_PREFIX + i + ACTIVITY_SAVE_SUFFIX;
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile activitySaveFile = await localFolder.CreateFileAsync(activitySaveFilename, CreationCollisionOption.OpenIfExists);
                string activity = await FileIO.ReadTextAsync(activitySaveFile);
                //string activityTextBoxName = ACTIVITY_TEXTBOX_PREFIX + i;
                TextBox activityTextBox = this.FindName(ACTIVITY_TEXTBOX_PREFIX + i) as TextBox;
                if (activity.Equals("") || activity.Equals("\r"))
                    activityTextBox.PlaceholderText = NO_ACTIVITY_MESSAGE;
                else
                    activityTextBox.PlaceholderText = ACTIVITY_MESSAGE_PREFIX + activity;
            }

            base.OnNavigatedTo(e);
        }

        public async void Save_Activities(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                TextBox activityTextBox = this.FindName(ACTIVITY_TEXTBOX_PREFIX + i) as TextBox;
                string activity = activityTextBox.Text;

                string activitySaveFilename = ACTIVITY_SAVE_PREFIX + i + ACTIVITY_SAVE_SUFFIX;
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                // Preserve current activity saved if empty text is entered into the corresponding TextBox
                if (activity.Equals("") || activity.Equals("\r") || activity.Equals("\n"))                    
                    continue;
                else
                {
                    StorageFile activitySaveFile = await localFolder.CreateFileAsync(activitySaveFilename, CreationCollisionOption.ReplaceExisting);
                    await FileIO.WriteTextAsync(activitySaveFile, activity);
                }
                    
            }
            var message = new MessageDialog("Activity assignments saved successfully.");
            await message.ShowAsync();
            // Update the existing assignments
            OnNavigatedTo(_pastNavigationEventArgs);
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
