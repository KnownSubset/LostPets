using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using Facebook;
using LostPets.ViewModels;
using Microsoft.Phone.Controls;
using TweetSharp;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace LostPets {
    public partial class SharePage : PhoneApplicationPage {
        public SharePage() {
            InitializeComponent();
        }

        private void Tweet(object sender, GestureEventArgs gestureEventArgs) {
            var twitterService = new TwitterService("qbRYCoIh1o9wG6CMiXJHfg", "5afCN0rTenjkPbfpIEh6moE0ERRUpVLunoFja5S64Ks");
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            var twitterAccessToken = "twitterAccessToken";
            var twitterAccessTokenSecret = "twitterAccessTokenSecret";
            if (settings.Contains(twitterAccessToken) && settings.Contains(twitterAccessTokenSecret)) {
                twitterService.AuthenticateWith(settings[twitterAccessToken] as string, settings[twitterAccessTokenSecret] as string);
                twitterService.SendTweet("Tweeting with #tweetsharp for #wp7", (tweet, response) => {
                                                                                   if (response.StatusCode != HttpStatusCode.OK) {
                                                                                       settings.Remove(twitterAccessToken);
                                                                                       settings.Remove(twitterAccessTokenSecret);
                                                                                   }
                                                                               });
            } else {
                NavigationService.Navigate(new Uri("/OAuthPage.xaml", UriKind.Relative));
            }
        }

        private void PostToWall(object sender, GestureEventArgs gestureEventArgs) {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("facebookAccessToken")) {
                var client = new FacebookClient(settings["facebookAccessToken"] as string);
                var parameters = new Dictionary<string, object>();
                parameters.Add("message", "testing Facebook C# SDK");
                parameters.Add("name", "Facebook C# SDK");
                parameters.Add("description", "The Facebook C# SDK helps .Net developers build web, desktop, Silverlight, and Windows Phone 7 applications that integrate with Facebook.");
                parameters.Add("privacy", new Dictionary<string, object> {{"value", "ALL_FRIENDS"}});
                client.PostCompleted +=ClientOnPostCompleted;
                client.PostAsync("me/feed", parameters);
            }else {
                NavigationService.Navigate(new Uri("/FacebookOAuthPage.xaml", UriKind.Relative));
            }
        }

        private void ClientOnPostCompleted(object sender, FacebookApiEventArgs facebookApiEventArgs) {
            if (facebookApiEventArgs.Error != null) {
                Dispatcher.BeginInvoke(() => MessageBox.Show("error posting to facebook"));
            }
        }

        private void SubmitForKarma(object sender, GestureEventArgs gestureEventArgs) {}
    }
}