﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPFinalProject.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page {
        private CloudAPI cloudAPI = null;

        public SettingsPage() {
            this.InitializeComponent();
        }

        private async void button_TestAPI_Click(object sender, RoutedEventArgs e) {
            if (cloudAPI == null) {
                cloudAPI = new CloudAPI();
            }

            Task<string> result = cloudAPI.ProbeAsync();
            ContentDialog probeDialog = new ContentDialog {
                Title = "Testing API connection",
                Content = await result,
                CloseButtonText = "Ok"
            };

            await probeDialog.ShowAsync();
        }
    }
}
