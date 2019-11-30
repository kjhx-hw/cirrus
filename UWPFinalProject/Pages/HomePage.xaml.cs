using System.Diagnostics;
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

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            Debug.WriteLine("INF: Beginning on-navigate functions...");
            ViewModel = new TrackViewModel(cloudAPI.GetPopularNow());
            headerText.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ProgressRing.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TrackGrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
    }
}
