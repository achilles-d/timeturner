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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace AppUIBasics.ControlPages
{
    public sealed partial class ProgressRingPage : Page
    {
        private readonly string CALENDAR_SAVE_FILE = "calendarEntrySaves.txt";
        private NavigationEventArgs _lastEventArgs;
        public ProgressRingPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            _lastEventArgs = e;

            StackPanel calendarPanel = this.FindName("CalendarsPanel") as StackPanel;
            calendarPanel.Children.Clear();

            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile calendarSaveFile = await localFolder.CreateFileAsync(CALENDAR_SAVE_FILE, CreationCollisionOption.OpenIfExists);
            string userInfoString = await FileIO.ReadTextAsync(calendarSaveFile);
            string[] calendarInfoLines = userInfoString.Split("\n");

            for (int i = 0; i < calendarInfoLines.Length; i++)
            {
                if (calendarInfoLines[i].Equals("") || calendarInfoLines[i].Equals("\r") || calendarInfoLines[i].Contains("\r\r"))
                    continue;
                string[] calendarInfoEntry = calendarInfoLines[i].Split("|");
                calendarPanel.Children.Add(createCalendarEntryButton(calendarInfoEntry[0], calendarInfoEntry[1]));
            }

            base.OnNavigatedTo(e);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            TextBlock emailTextBlock = clickedButton.FindName("Email") as TextBlock;
            string email = emailTextBlock.Text;
            
            ContentDialog deleteCalendarEntryDialog = new ContentDialog
            {
                Title = "Delete calendar?",
                Content = "This action cannot be undone.",
                PrimaryButtonText = "Confirm",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteCalendarEntryDialog.ShowAsync();

            if(result == ContentDialogResult.Primary)
            {
                deleteCalendarEntry(email);
                var deleteMessage = new MessageDialog("Calendar deleted successfully.");
                await deleteMessage.ShowAsync();
                OnNavigatedTo(_lastEventArgs);
            }
        }


        private async void deleteCalendarEntry(string email)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile calendarSaveFile = await localFolder.CreateFileAsync(CALENDAR_SAVE_FILE, CreationCollisionOption.OpenIfExists);
            string userInfoString = await FileIO.ReadTextAsync(calendarSaveFile);
            string[] calendarInfoLines = userInfoString.Split("\n");

            // Erase file
            await localFolder.CreateFileAsync(CALENDAR_SAVE_FILE, CreationCollisionOption.ReplaceExisting);

            // Rewrite contents without the unwanted calendar
            for (int i = 0; i < calendarInfoLines.Length; i++)
            {
                if (calendarInfoLines[i].Contains(email) || calendarInfoLines[i].Equals("\r") || calendarInfoLines[i].Equals(""))
                    continue;
                else
                {
                    await FileIO.AppendLinesAsync(calendarSaveFile, new string[] { calendarInfoLines[i] });
                }
            }
        }

        private Button createCalendarEntryButton(string email, string serviceType)
        {
            Button calendarEntryButton = new Button();
            calendarEntryButton.Height = 138;
            calendarEntryButton.Click += Button_Click;

            StackPanel addedCalendarPanel = new StackPanel();
            addedCalendarPanel.Orientation = Orientation.Horizontal;
            addedCalendarPanel.Width = 452;
            addedCalendarPanel.Height = 181;
            addedCalendarPanel.Spacing = 20;
            addedCalendarPanel.HorizontalAlignment = HorizontalAlignment.Center;
            addedCalendarPanel.VerticalAlignment = VerticalAlignment.Center;

            Image serviceIcon = new Image();
            string serviceIconPath = "ms-appx:///Assets/";
            if (serviceType.Equals("Outlook"))
                serviceIconPath += "outlook_blue.png";
            else if (serviceType.Equals("Google"))
                serviceIconPath += "google_blue.png";
            else
                serviceIconPath += "apple_blue.png";
            serviceIcon.Source = new BitmapImage(new Uri(serviceIconPath));
            serviceIcon.Height = 100;
            serviceIcon.HorizontalAlignment = HorizontalAlignment.Left;
            serviceIcon.VerticalAlignment = VerticalAlignment.Center;

            StackPanel innerCalendarPanel = new StackPanel();
            innerCalendarPanel.Orientation = Orientation.Vertical;
            innerCalendarPanel.Height = 100;
            innerCalendarPanel.HorizontalAlignment = HorizontalAlignment.Center;

            TextBlock serviceNameTextBlock = new TextBlock();
            serviceNameTextBlock.Text = serviceType;
            serviceNameTextBlock.TextWrapping = TextWrapping.Wrap;
            serviceNameTextBlock.FontSize = 40;
            serviceNameTextBlock.Width = 292;
            serviceNameTextBlock.Height = 61;
            serviceNameTextBlock.VerticalAlignment = VerticalAlignment.Center;

            TextBlock emailTextBlock = new TextBlock();
            emailTextBlock.Text = email;
            emailTextBlock.TextWrapping = TextWrapping.Wrap;
            emailTextBlock.FontSize = 26;
            emailTextBlock.Width = 292;
            emailTextBlock.Height = 61;
            emailTextBlock.VerticalAlignment = VerticalAlignment.Center;
            emailTextBlock.Name = "Email";

            innerCalendarPanel.Children.Add(serviceNameTextBlock);
            innerCalendarPanel.Children.Add(emailTextBlock);
            addedCalendarPanel.Children.Add(serviceIcon);
            addedCalendarPanel.Children.Add(innerCalendarPanel);
            calendarEntryButton.Content = addedCalendarPanel;

            return calendarEntryButton;
        }
    }
}
