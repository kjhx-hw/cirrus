using SoundCloud.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UWPFinalProject.Model {
    class LocalStorage {
        private string storedFavorites;
        private List<int> favoritesList;

        public string StoredFavorites {
            get {
                return storedFavorites;
            }
            set {
                storedFavorites = value;
            }
        }
        public LocalStorage() {

        }
        public void addItem(string newItem) {
            int newId = Convert.ToInt32(newItem);
            if(favoritesList.Contains(newId)) {
                //alert user that item is already in favorites list
            } else {
                favoritesList.Add(newId);
            }
        }

        public void deleteItem(string itemToDelete)
        {
            int IdToDelete = Convert.ToInt32(itemToDelete);
            if (favoritesList.Contains(IdToDelete)) {
                favoritesList.Remove(IdToDelete);
            }
        }
        public void serializeFavorites() {
            string json = JsonConvert.SerializeObject(favoritesList);
            storedFavorites = json;
        }
        public void deserializeFavorites() {
            favoritesList = JsonConvert.DeserializeObject<List<int>>(storedFavorites);
        }
    }
}
