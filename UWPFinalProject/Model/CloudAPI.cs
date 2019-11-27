using SoundCloud.Api;
using SoundCloud.Api.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UWPFinalProject.Model {
    class CloudAPI {
        private const string CLIENT_KEY = "b4901850db2a3fd767b36a91a2793cef";
        private ISoundCloudClient client = null;

        /// <summary>
        /// Class constructor initializes API connection with our
        /// CLIENT_KEY, and saves that key for the rest of our queries.
        /// </summary>
        public CloudAPI() {
            client = SoundCloudClient.CreateUnauthorized(CLIENT_KEY);
            Debug.WriteLine("CloudAPI instantiated.");
        }

        /// <summary>
        /// When passed in a single Track Id, fetches it from the API
        /// and returns that Track back to the caller.
        /// </summary>
        public async Task<Track> GetTrack(int Id) {
            Track result = null;

            try {
                result = await client.Tracks.GetAsync(Id);
            } catch (SoundCloud.Api.Exceptions.SoundCloudApiException e) {
                Debug.WriteLine("ERR: GetTrackData failed: " + e.HttpStatusCode);
            }

            return result;
        }

        /// <summary>
        /// When passed in a List of Track Ids, iterates through the List
        /// and fetches each Track, returning them as a List of Tracks.
        /// </summary>
        public async Task<List<Track>> GetAllTracks(List<int> idList) {
            List<Track> result = null;

            foreach (var id in idList) {
                try {
                    Track track = await client.Tracks.GetAsync(id);
                    result.Add(track);
                } catch (SoundCloud.Api.Exceptions.SoundCloudApiException e) {
                    Debug.WriteLine("ERR: Could not get track data for track " + id + "(" + e.HttpStatusCode + ")");
                }
            }

            return result;
        }

        /// <summary>
        /// Tests the API connection by requesting the Track Id of
        /// a known track, then comparing the returned value. This
        /// function is for early debug only.
        /// </summary>
        public async Task<string> ProbeAsync() {
            string callback = "404";
            Track result = await client.Tracks.GetAsync(192688656);
            Debug.WriteLine("Sent = 192688656");
            callback = result.Id.ToString();
            Debug.WriteLine("Rcvd = " + callback);
            return callback;
        }
    }
}
