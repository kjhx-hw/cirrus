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
        public TrackViewModel ViewModel { get; set; }

        public HomePage() {
            this.InitializeComponent();

            if (cloudAPI == null) {
                cloudAPI = new CloudAPI();
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            Debug.WriteLine("INF: Beginning on-navigate functions...");
            //System.Collections.Generic.List<SoundCloud.Api.Entities.Track> result = await Task.Run(() => cloudAPI.GetPopularNow());
            Debug.WriteLine("INF: Populating view...");
            //ViewModel = new TrackViewModel(result);
            this.ViewModel = new TrackViewModel();
            Debug.WriteLine("INF: Done!");
            ProgressRing.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ProgressRing.IsActive = false;
            TrackGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void TrackGrid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) {
            Track selectedItem = TrackGrid.SelectedItems[0] as Track;
            Debug.WriteLine(selectedItem.TrackId);
            Frame.Navigate(typeof(PlayerPage), selectedItem);
            
        }
    }
}
