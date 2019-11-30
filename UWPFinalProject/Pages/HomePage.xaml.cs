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
            System.Collections.Generic.List<SoundCloud.Api.Entities.Track> result = await Task.Run(() => cloudAPI.GetPopularNow());
            Debug.WriteLine("INF: Populating view...");
            ViewModel = new TrackViewModel(result);
        }
    }
}
