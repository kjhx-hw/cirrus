using SoundCloud.Api;
using SoundCloud.Api.Entities;
using SoundCloud.Api.Entities.Base;
using SoundCloud.Api.QueryBuilders;
using System;
using System.Threading.Tasks;

namespace ConsoleAPI {
    class Program {
        private const string CLIENT_KEY = "b4901850db2a3fd767b36a91a2793cef";

        static async System.Threading.Tasks.Task Main(string[] args) {
            // CTRL FN F5
            // Top 40 playlist: 212109430

            ISoundCloudClient client = SoundCloudClient.CreateUnauthorized(CLIENT_KEY);
            Console.WriteLine("Created API client with ID " + CLIENT_KEY);

            var playlist = await client.Playlists.GetAsync(212109430);
            foreach (var item in playlist.Tracks) {
                Console.WriteLine(item.Title);
            }
        }

        private static async Task PageThrough<T>(SoundCloudList<T> list, Func<T, string> selector) where T : Entity {
            Console.WriteLine();
            Console.WriteLine("Results:");

            while (true) {
                Console.WriteLine();

                foreach (var item in list) {
                    Console.WriteLine(selector(item));
                }

                if (!list.HasNextPage) {
                    Console.WriteLine();
                    Console.Write("No more items.");
                    return;
                }

                Console.WriteLine();
                Console.Write("Next page? [Y|n]: ");
                var answer = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(answer) || answer == "y") {
                    // Get next page of current list
                    list = await list.GetNextPageAsync();
                } else {
                    return;
                }
            }
        }
    }
}
