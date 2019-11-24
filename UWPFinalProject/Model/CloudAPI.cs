using SoundCloud.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPFinalProject.Model {
    class CloudAPI {
        private const string CLIENT_KEY = "b4901850db2a3fd767b36a91a2793cef";
        private ISoundCloudClient client = null;

        public CloudAPI() {
            client = SoundCloudClient.CreateUnauthorized(CLIENT_KEY);
            Debug.WriteLine("CloudAPI instantiated.");
        }

        public async Task<string> ProbeAsync() {
            string callback = "404";
            SoundCloud.Api.Entities.Track result = await client.Tracks.GetAsync(192688656);
            Debug.WriteLine("Sent = 192688656");
            callback = result.Id.ToString();
            Debug.WriteLine("Rcvd = " + callback);
            return callback;
        }
    }
}
