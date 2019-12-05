using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.System.Display;

namespace UWPFinalProject.Model {
    class Player {
        CloudAPI CloudAPI = null;
        MediaPlayer mediaPlayer = null;

        public Player() {
            Debug.WriteLine("INF: Player init...");

            if (CloudAPI == null) {
                CloudAPI = new CloudAPI();
            }

            if (mediaPlayer == null) {
                mediaPlayer = new MediaPlayer();
            }

            Debug.WriteLine("INF: Done!");
        }

        public async Task<SoundCloud.Api.Entities.Track> FetchTrackEntity(long Id) {
            SoundCloud.Api.Entities.Track track = null;

            Debug.WriteLine("INF: Player: Fetching Track " + Id);
            track = await CloudAPI.GetTrack(Id);

            return track;
        }
        
        public void StreamFromURL(string Url) {
            mediaPlayer.AudioCategory = MediaPlayerAudioCategory.Media;
            mediaPlayer.AutoPlay = true;
            // set source
            Uri uri = new Uri(Url);
            mediaPlayer.Source = MediaSource.CreateFromUri(uri);
        }

        public void Pause() {
            mediaPlayer.Pause();
        }

        public void Play() {
            mediaPlayer.Play();
        }

        public void ClosePlayer() {
            mediaPlayer.Dispose();
        }
    }
}
