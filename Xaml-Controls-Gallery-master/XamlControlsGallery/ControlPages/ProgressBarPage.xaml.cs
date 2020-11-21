//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppUIBasics.ControlPages
{
    public sealed partial class ProgressBarPage : Page
    {
        public ProgressBarPage()
        {
            this.InitializeComponent();
        }

        private void ProgressValue_ValueChanged(Microsoft.UI.Xaml.Controls.NumberBox sender, Microsoft.UI.Xaml.Controls.NumberBoxValueChangedEventArgs args)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ControlPages.CalendarInfoForm), "Outlook");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ControlPages.CalendarInfoForm), "Google");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ControlPages.CalendarInfoForm), "iCloud");
        }
    }
}
