using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundCloud.Api.Entities;

namespace UWPFinalProject.Pages {
    public class TrackViewModel {
        private ObservableCollection<Track> tracks = new ObservableCollection<Track>();
        private Task<List<SoundCloud.Api.Entities.Track>> task;

        public ObservableCollection<Track> Tracks { get { return tracks; } }

        /// <summary>
        /// If called without arguments, will simply populate
        /// the view with 50 of the default track.
        /// </summary>
        public TrackViewModel(List<SoundCloud.Api.Entities.Track> result) {
            for (int i = 0; i < 50; i++) {
                this.tracks.Add(new Track());
            }
        }

        public TrackViewModel(Task<List<SoundCloud.Api.Entities.Track>> task) {
            this.task = task;
            foreach (var item in task.Result) {
                this.tracks.Add(new Track() {
                    TrackName = item.Title,
                    ArtistName = item.User.FullName,
                    TrackId = item.Id,
                    TrackArtUrl = item.ArtworkUrl.ToString()
                });
            }
        }
    }
}
