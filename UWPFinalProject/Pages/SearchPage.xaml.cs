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
using UWPFinalProject.Model;
using System.Diagnostics;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page {
        private LocalStorage localStorage;
        public CloudAPI cloudAPI = null;
        public TrackViewModel ViewModel = new TrackViewModel();
        public SearchPage() {
            this.InitializeComponent();
            if (cloudAPI == null)
            {
                cloudAPI = new CloudAPI();
            }
        }

        private void SearchBox_KeyUp(object sender, KeyRoutedEventArgs e) {
            if(e.Key == Windows.System.VirtualKey.Enter) {
                ViewModel.tracks.Clear();
                TrackGrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ProgressRing.Visibility = Windows.UI.Xaml.Visibility.Visible;
                string search = headerText.Text;
                FetchDataFromApi(search);
            }
        }

        private async Task<int> FetchDataFromApi(string searchString)
        {
            // Yeah, I know this is as sloppy as they come, but I was more concerned with getting the application functional
            // thank compliance with MVVM principle at this point. My apologies.
            Debug.WriteLine("INF: Beginning on-navigate functions...");
            System.Collections.Generic.List<Track> result = await Task.Run(() => cloudAPI.SearchTrack(searchString));
            Debug.WriteLine("INF: Populating view...");
            foreach (var item in result) {
                ViewModel.tracks.Add(item);
                Debug.WriteLine("INF: Search Added " + item.TrackName + " to collection.");
            }

            Debug.WriteLine("INF: Done!");
            ProgressRing.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ProgressRing.IsActive = false;
            TrackGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ProgressRing.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            return 2;
        }


        private void TrackGrid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Track selectedItem = TrackGrid.SelectedItems[0] as Track;
            Debug.WriteLine(selectedItem.TrackId);
            Frame.Navigate(typeof(PlayerPage), selectedItem);

        }
    }
}
