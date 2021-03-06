using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;

namespace AppUIBasics.ControlPages
{
    public sealed partial class DropDownButtonPage : Page
    {
        public DropDownButtonPage()
        {
            this.InitializeComponent();
        }

        private void ControlExample_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var breakNotificationContent = new ToastContentBuilder()
            .AddText("Break Scheduled", hintMaxLines: 1)
            .AddText("Monday, Novemeber 23")
            .AddText("10:00 AM - 10:30 AM")
            .GetToastContent();

            var breakNotification = new ToastNotification(breakNotificationContent.GetXml());

            ToastNotificationManager.CreateToastNotifier().Show(breakNotification);

        }
    }
}
