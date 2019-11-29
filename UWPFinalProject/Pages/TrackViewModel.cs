using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPFinalProject.Pages {
    public class TrackViewModel {
        private ObservableCollection<Track> tracks = new ObservableCollection<Track>();
        public ObservableCollection<Track> Tracks { get { return this.tracks; } }

        public TrackViewModel() {
            for (int i = 0; i < 50; i++) {
                this.tracks.Add(new Track());
            }
        }
    }
}
