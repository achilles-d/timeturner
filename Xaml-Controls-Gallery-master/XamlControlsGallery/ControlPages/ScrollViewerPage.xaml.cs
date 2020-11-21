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
using System.Net;
using Windows.Storage;
//using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace AppUIBasics.ControlPages
{
    public sealed partial class ScrollViewerPage : Page
    {
        public ScrollViewerPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = new MessageDialog("Sleep time: \n" +
                "Weekly stats:13 hours\n" + "Target:50 hours");
            await message.ShowAsync();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            var message = new MessageDialog("Calander download successfully!");
            await message.ShowAsync();
            StorageFolder localfolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            using (WebClient wc = new WebClient())
            {
                //wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFile(new Uri("https://www.phpclasses.org/browse/download/1/file/63438/name/example.ics"), localfolder.Path+"/example.ics");
            }
            
        }

        private void progress_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            
        }
    }
}
