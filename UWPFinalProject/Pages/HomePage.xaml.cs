using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page {
        public TrackViewModel ViewModel { get; set; }

        public HomePage() {
            this.InitializeComponent();
            this.ViewModel = new TrackViewModel();
        }
    }
}
