using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPFinalProject.Pages {
    public class Track {
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
        public int TrackId { get; set; }
        public string TrackArtUrl { get; set; }

        public Track() {
            // Defaults
            this.TrackName = "Hobnotropic";
            this.ArtistName = "matas";
            this.TrackId = 49931;
            this.TrackArtUrl = "https://i1.sndcdn.com/artworks-000000103093-941e7e-large.jpg";
        }
    }
}
