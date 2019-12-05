using System.Diagnostics;
using System.Threading.Tasks;
using UWPFinalProject.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page {
        public CloudAPI cloudAPI = null;
        public TrackViewModel ViewModel = new TrackViewModel();

        public HomePage() {
            this.InitializeComponent();

            if (cloudAPI == null) {
                cloudAPI = new CloudAPI();
            }

            #pragma warning disable CS4014 // Force compiler to stop whining about my lack of await keyword
            FetchDataFromApi();
            #pragma warning restore CS4014
        }

        private async Task<int> FetchDataFromApi() {
            // Yeah, I know this is as sloppy as they come, but I was more concerned with getting the application functional
            // thank compliance with MVVM principle at this point. My apologies.
            Debug.WriteLine("INF: Beginning on-navigate functions...");
            System.Collections.Generic.List<SoundCloud.Api.Entities.Track> result = await Task.Run(() => cloudAPI.GetPopularNow());
            Debug.WriteLine("INF: Populating view...");
            foreach (var item in result) {
                if (item.ArtworkUrl != null) {
                    ViewModel.tracks.Add(new Track {
                        TrackName = item.Title,
                        TrackArtUrl = item.ArtworkUrl.AbsoluteUri,
                        TrackId = item.Id,
                        ArtistName = item.User.Username
                    });
                }

                Debug.WriteLine("INF: Added " + item.Title + " to collection.");
            }

            Debug.WriteLine("INF: Done!");
            ProgressRing.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ProgressRing.IsActive = false;
            TrackGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
            return 2;
        }

        private void TrackGrid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) {
            Track selectedItem = TrackGrid.SelectedItems[0] as Track;
            Debug.WriteLine(selectedItem.TrackId);
            Frame.Navigate(typeof(PlayerPage), selectedItem);
            
        }
    }
}
