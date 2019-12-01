using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPFinalProject.Pages {
    public class Track {
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
        public long TrackId { get; set; }
        public string TrackArtUrl { get; set; }

        public Track() {
            // Defaults
            this.TrackName = "Hobnotropic";
            this.ArtistName = "matas";
            this.TrackId = 49931;
            this.TrackArtUrl = "https://i1.sndcdn.com/artworks-000000103093-941e7e-large.jpg";
        }

        public override string ToString() {
            string debugString = "Track:";
            debugString += " " + this.TrackName + " by " + this.ArtistName + ".";
            debugString += "\nTrackID " + this.TrackId + ".";
            return debugString;
        }
    }
}
