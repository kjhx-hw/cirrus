using UWPFinalProject.Model;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UWPFinalProject.Pages;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyMusicPage : Page {
        private LocalStorage localStorage;
        public CloudAPI cloudAPI = null;
        public TrackViewModel ViewModel = new TrackViewModel();
        public MyMusicPage() {
            this.InitializeComponent();
            localStorage = new LocalStorage();

            if (cloudAPI == null)
            {
                cloudAPI = new CloudAPI();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string x = localStorage.StoredFavorites;
            string y = (string)ApplicationData.Current.LocalSettings.Values["Json"];
            //deserialize the json and populate the list should the list exist
            if(y != null && y != x) {
                localStorage.deserializeFavorites();
            }
            #pragma warning disable CS4014 // Force compiler to stop whining about my lack of await keyword
            FetchDataFromApi();
            #pragma warning restore CS4014
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            localStorage.serializeFavorites();
            //serialize the json and store it in LocalSettings
        }

        private async Task<int> FetchDataFromApi()
        {
            // Yeah, I know this is as sloppy as they come, but I was more concerned with getting the application functional
            // thank compliance with MVVM principle at this point. My apologies.
            Debug.WriteLine("INF: Beginning on-navigate functions...");
            System.Collections.Generic.List<SoundCloud.Api.Entities.Track> result = await Task.Run(() => cloudAPI.GetAllTracks(localStorage.FavoritesList));
            Debug.WriteLine("INF: Populating view...");
            foreach (var item in result)
            {
                if (item.ArtworkUrl != null)
                {
                    ViewModel.tracks.Add(new Track
                    {
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

        private void TrackGrid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Track selectedItem = TrackGrid.SelectedItems[0] as Track;
            Debug.WriteLine(selectedItem.TrackId);
            Frame.Navigate(typeof(PlayerPage), selectedItem);

        }
    }
}
