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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages {
    public sealed partial class PlayerPage : Page {
        public const string TOGGLE_ICON_PAUSE = "pause";
        public const string TOGGLE_ICON_PLAY = "play";
        public const string TOGGLE_ICON_LOVE = "love";
        public const string TOGGLE_ICON_UNLOVE = "unlove";

        Track passedTrack = null;
        SoundCloud.Api.Entities.Track fetchedTrack = null;

        public PlayerPage() {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            passedTrack = e.Parameter as Track;
            // get playermodel trackdata

            PlayToggle.Content = TOGGLE_ICON_PAUSE;
        }

        private async void DebugButton_Tapped(object sender, TappedRoutedEventArgs e) {
            ContentDialog dialog = new ContentDialog {
                Title = "Debug Information",
                Content = passedTrack.ToString(),
                CloseButtonText = "OK"
            };

            await dialog.ShowAsync();
        }

        private void PlayToggle_Tapped(object sender, TappedRoutedEventArgs e) {
            if (PlayToggle.Content.ToString() == TOGGLE_ICON_PAUSE) {
                // pause stream
                PlayToggle.Content = TOGGLE_ICON_PLAY;
            } else {
                // resume stream
                PlayToggle.Content = TOGGLE_ICON_PAUSE;
            }
        }

        private void FavToggle_Tapped(object sender, TappedRoutedEventArgs e) {

        }
    }
}
