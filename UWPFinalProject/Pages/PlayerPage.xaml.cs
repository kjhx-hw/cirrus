﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPFinalProject.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinalProject.Pages {
    public sealed partial class PlayerPage : Page {
        public const string TOGGLE_ICON_PAUSE = "⏸";
        public const string TOGGLE_ICON_PLAY = "►";
        public const string TOGGLE_ICON_LOVE = "♡";
        public const string TOGGLE_ICON_UNLOVE = "♥";

        private LocalStorage localstorage;


        Player model = new Player();

        Track passedTrack = null;
        SoundCloud.Api.Entities.Track fetchedTrack = null;

        public PlayerPage() {
            this.InitializeComponent();
            localstorage = new LocalStorage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            passedTrack = e.Parameter as Track;
            getTrackDataAsync();

            PlayToggle.Content = TOGGLE_ICON_PAUSE;
            if(localstorage.FavoritesList.Contains(passedTrack.TrackId)) {
                FavoriteToggle.Content = TOGGLE_ICON_UNLOVE;
            } else {
                FavoriteToggle.Content = TOGGLE_ICON_LOVE;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e) {
            base.OnNavigatedFrom(e);
            model.ClosePlayer();
        }

        private async void getTrackDataAsync() {
            SoundCloud.Api.Entities.Track track = null;
            track = await model.FetchTrackEntity(passedTrack.TrackId);
            fetchedTrack = track;
            model.StreamFromURL(fetchedTrack.StreamUrl.AbsoluteUri + "?client_id=b4901850db2a3fd767b36a91a2793cef");

            playsText.Text = track.PlaybackCount.ToString() + playsText.Text;
            heartsText.Text = track.LikesCount.ToString() + heartsText.Text;
            commentsText.Text = track.CommentCount.ToString() + commentsText.Text;

            ProgressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            PlayToggle.Visibility = Windows.UI.Xaml.Visibility.Visible;
            FavoriteToggle.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private async void DebugButton_Tapped(object sender, TappedRoutedEventArgs e) {
            ContentDialog dialog = new ContentDialog {
                Title = "Debug Information",
                Content = passedTrack.ToString(),
                CloseButtonText = "OK"
            };

            await dialog.ShowAsync();
        }

        private void PlayToggle_Tapped(object sender, TappedRoutedEventArgs e) {
            if (PlayToggle.Content.ToString() == TOGGLE_ICON_PAUSE) {
                model.Pause();
                PlayToggle.Content = TOGGLE_ICON_PLAY;
            } else {
                model.Play();
                PlayToggle.Content = TOGGLE_ICON_PAUSE;
            }
        }

        private void FavToggle_Tapped(object sender, TappedRoutedEventArgs e) {
            if (localstorage.FavoritesList.Contains(passedTrack.TrackId)) {
                //remove from favorites list
                localstorage.deleteItem(passedTrack.TrackId);
                localstorage.serializeFavorites();
                FavoriteToggle.Content = TOGGLE_ICON_LOVE;
            } else {
                //add to favorites list
                localstorage.addItem(passedTrack.TrackId);
                localstorage.serializeFavorites();
                FavoriteToggle.Content = TOGGLE_ICON_UNLOVE;
            }
        }
    }
}
