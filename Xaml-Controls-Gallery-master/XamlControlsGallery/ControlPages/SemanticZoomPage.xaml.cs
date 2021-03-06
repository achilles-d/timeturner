//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************
using AppUIBasics.Data;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppUIBasics.ControlPages
{
    public sealed partial class SemanticZoomPage : Page
    {
        private IEnumerable<ControlInfoDataGroup> _groups;
        public class Storage_msg
        {
            public string Textdata { get; set; }
        }
        public SemanticZoomPage()
        {
            this.InitializeComponent();
            this.DataContext = new Storage_msg() { Textdata = "34.5MB used on C: (system drive)\nSince 10/20/2020"};
        }
        public IEnumerable<ControlInfoDataGroup> Groups
        {
            get { return this._groups; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _groups = ControlInfoDataSource.Instance.Groups;
        }

        private void List_GotFocus(object sender, RoutedEventArgs e)
        {
            //Control1.StartBringIntoView();
            
        }

        private void Example1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Storage = "No data Saved yet";
            var message = new MessageDialog("Are you sure that you want to delete all activity tracking data? This action cannot be undone.");
            message.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            message.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            await message.ShowAsync();
        }
        private async void CommandInvokedHandler(IUICommand command) {
            if (command.Label == "Yes") {
                var message = new MessageDialog("Data deleted successfully");
                await message.ShowAsync();
                this.DataContext = new Storage_msg() { Textdata = "No data saved yet\nSince 10/20/2020" };
            }
        }
        private void TextBlock_SelectionChanged_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_3(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
