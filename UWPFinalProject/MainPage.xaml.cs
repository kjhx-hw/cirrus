using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPFinalProject.Pages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPFinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// Navigation functions largely from https://blogs.msmvps.com/bsonnino/2019/02/13/navigationview-in-uwp/
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        private NavigationViewItem _lastItem;

        private void NavigationView_OnItemInvoked(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewItemInvokedEventArgs args) {
            var item = args.InvokedItemContainer as NavigationViewItem;

            if (item == null || item == _lastItem) {
                return;
            }

            var clickedView = item.Tag?.ToString() ?? "SettingsPage";
            if (!NavigateToView(clickedView)) return;
            _lastItem = item;
        }

        private bool NavigateToView(string clickedView) {
            var view = Assembly.GetExecutingAssembly().GetType($"UWPFinalProject.Pages.{clickedView}");
            Debug.WriteLine("Navigating to " + clickedView + " (" + view + ")");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null) {
                return false;
            }

            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        private void ContentFrame_OnNavigationFailed(object sender, NavigationFailedEventArgs e) {
            throw new NavigationException($"Navigation failed {e.Exception.Message} for {e.SourcePageType.FullName}");
        }

        private void NavView_OnBackRequested(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewBackRequestedEventArgs args) {
            if (ContentFrame.CanGoBack) {
                ContentFrame.GoBack();
            }
        }

        internal class NavigationException : Exception {
            public NavigationException(string msg) : base(msg) {
                // hmm
            }
        }

        private void nav_Loaded(object sender, RoutedEventArgs e) {
            nav.SelectedItem = nav.MenuItems[0];
            NavigateToView("HomePage");
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e) {
            var cframe = ContentFrame.CurrentSourcePageType;
            if (cframe.Name == "PlayerPage") {
                nav.SelectedItem = null;
            }
        }
    }
}
