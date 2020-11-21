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
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;

namespace AppUIBasics.ControlPages
{
    
    public sealed partial class AutomationPropertiesPage : Page
    {
        private readonly string CALENDAR_SAVE_FILE = "calendarEntrySaves.txt";
        public AutomationPropertiesPage()
        {
            this.InitializeComponent();
        }

        /*
         * Refresh the displayed list of saved calendars whenever the page is accessed
         */
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            StackPanel calendarPanel = this.FindName("CalendarsPanel") as StackPanel;
            calendarPanel.Children.Clear();

            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile calendarSaveFile = await localFolder.CreateFileAsync(CALENDAR_SAVE_FILE, CreationCollisionOption.OpenIfExists);
            string userInfoString = await FileIO.ReadTextAsync(calendarSaveFile);
            string[] calendarInfoLines = userInfoString.Split("\n");
            
            for(int i = 0; i < calendarInfoLines.Length; i++)
            {
                if (calendarInfoLines[i].Equals(""))
                    break;
                string[] calendarInfoEntry = calendarInfoLines[i].Split("|");
                calendarPanel.Children.Add(createCalendarEntryPanel(calendarInfoEntry[0], calendarInfoEntry[1]));
            }
        
            base.OnNavigatedTo(e);
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private StackPanel createCalendarEntryPanel(string email, string serviceType)
        {
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

            innerCalendarPanel.Children.Add(serviceNameTextBlock);
            innerCalendarPanel.Children.Add(emailTextBlock);
            addedCalendarPanel.Children.Add(serviceIcon);
            addedCalendarPanel.Children.Add(innerCalendarPanel);

            return addedCalendarPanel;
        }
}
}
