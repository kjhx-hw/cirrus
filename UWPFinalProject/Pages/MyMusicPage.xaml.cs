using UWPFinalProject.Model;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyMusicPage : Page {
        private LocalStorage localStorage;
        public MyMusicPage() {
            this.InitializeComponent();
            localStorage = new LocalStorage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string x = localStorage.StoredFavorites;
            string y = (string)ApplicationData.Current.LocalSettings.Values["Json"];
            //deserialize the json and populate the list should the list exist
            if(ApplicationData.Current.LocalSettings.Values["Json"] != null) {
                localStorage.deserializeFavorites();
            }
            TestText.Text = localStorage.FavoritesList[localStorage.FavoritesList.Count - 1].ToString();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            localStorage.addItem("456");
            localStorage.serializeFavorites();
            //serialize the json and store it in LocalSettings
        }
    }
}
