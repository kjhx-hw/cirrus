using SoundCloud.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;

namespace UWPFinalProject.Model {
    public class LocalStorage {
        private string storedFavorites;
        private List<long> favoritesList;

        public string StoredFavorites {
            get {
                return storedFavorites;
            }

            set { 
                
            }
        }

        public List<long> FavoritesList {
            get {
                return favoritesList;
            }
            set { }
        }
        
        //initalize LocalStorage
        //should LocalSettings Already exist, populate object with stored data
        //if not, create new data
        public LocalStorage() {

            storedFavorites = (string)ApplicationData.Current.LocalSettings.Values["Json"];
            if (storedFavorites != null && storedFavorites != "") { 
                favoritesList = JsonConvert.DeserializeObject<List<long>>(storedFavorites);
            } else {
                favoritesList = new List<long>();
                storedFavorites = "";
            }
        }

        //add an item to the list of favorites
        //don't let the user add a song that already exists
        public void addItem(long newItemId) {
            //should probably make sure only a number is passed!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if(favoritesList.Contains(newItemId)) {
                //alert user that item is already in favorites list
            } else {
                favoritesList.Add(newItemId);
            }
        }

        //remove an item from the list of favorites
        //don't let them remove a song that doesn't exist
        public void deleteItem(long IdToDelete)
        {
            if (favoritesList.Contains(IdToDelete)) {
                favoritesList.Remove(IdToDelete);
            } else {
                //alert user that item does not exist
            }
        }

        //serialize the list into a json stringand store it
        public void serializeFavorites() {
            string json = JsonConvert.SerializeObject(favoritesList);
            storedFavorites = json;
            ApplicationData.Current.LocalSettings.Values["Json"] = json;
        }

        //retrieve the data from LocalSettings and deserialize it into the  favoritesList
        public void deserializeFavorites() {
            storedFavorites = (string)ApplicationData.Current.LocalSettings.Values["Json"];
            favoritesList = JsonConvert.DeserializeObject<List<long>>(storedFavorites);
        }
    }
}
