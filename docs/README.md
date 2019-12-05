# ![Logo Header](img/header.png)

[![Azure Build Status](https://dev.azure.com/KHUGGINS/Cirrus/_apis/build/status/kjhx.cirrus?branchName=master)](https://dev.azure.com/KHUGGINS/Cirrus/_build/latest?definitionId=1&branchName=master)

## Cirrus

A barebones SoundCloud client that allows you to search, browse, play music, and maintain a local list of favorite tracks.

Written by Kyle Huggins and Riley Judd for COMP 4450.

## MVVM

### Model
* `UWPFinalProject/Model/CloudAPI.cs`
* `UWPFinalProject/Model/LocalStorage.cs`
* `UWPFinalProject/Model/Player.cs`

### View
* `UWPFinalProject/Pages/HomePage.*`
* `UWPFinalProject/Pages/MyMusicPage.*`
* `UWPFinalProject/Pages/PlayerPage.*`
* `UWPFinalProject/Pages/SearchPage.*`
* `UWPFinalProject/Pages/SettingsPage.*`

### ViewModel
* `UWPFinalProject/Pages/TrackViewModel.cs`

## Dependencies

- [SoundCloud.Api](soundcloudapi)

[soundcloudapi]: https://github.com/prayzzz/SoundCloud.Api
