using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPFinalProject.Model {
    class Player {
        CloudAPI CloudAPI = null;

        public Player() {
            Debug.WriteLine("INF: Player init...");

            if (CloudAPI == null) {
                CloudAPI = new CloudAPI();
            }

            Debug.WriteLine("INF: Done!");
        }

        public SoundCloud.Api.Entities.Track FetchTrackEntity(long Id) {
            SoundCloud.Api.Entities.Track track = null;

            Debug.WriteLine("INF: Player: Fetching Track " + Id);

            return track;
        }
    }
}
