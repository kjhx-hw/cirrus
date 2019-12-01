using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundCloud.Api.Entities;

namespace UWPFinalProject.Pages {
    public class TrackViewModel {
        private ObservableCollection<SoundCloud.Api.Entities.Track> tracks = new ObservableCollection<SoundCloud.Api.Entities.Track>();
        public ObservableCollection<SoundCloud.Api.Entities.Track> Tracks { get { return this.tracks; } }

        /// <summary>
        /// If called without arguments, will simply populate
        /// the view with 50 of the default track.
        /// </summary>
        public TrackViewModel() {
            Debug.WriteLine("WRN: Using default dataset.");
            for (int i = 0; i < 50; i++) {
                SoundCloud.Api.Entities.Track temp = new SoundCloud.Api.Entities.Track();

                temp.Title = "Hobnotropic";
                temp.User = new User { FullName = "matas" };
                temp.Id = 49931;
                temp.ArtworkUrl = new Uri("https://i1.sndcdn.com/artworks-000000103093-941e7e-large.jpg");
            }
        }

        public TrackViewModel(ObservableCollection<SoundCloud.Api.Entities.Track> passedTracks) {
            foreach (var item in passedTracks) {
                if (item.ArtworkUrl == null) {
                    //Debug.WriteLine("WRN: ArtworkUrl null. Setting to default.");
                    //item.ArtworkUrl = new Uri("../Assets/Placeholder.jpg");
                }

                this.tracks.Add(item);
            }
        }
    }
}
