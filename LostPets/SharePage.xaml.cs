using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using System.Windows.Media;
using Facebook;
using LostPets.ViewModels;
using Microsoft.Phone.Controls;
using TweetSharp;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace LostPets {
    public partial class SharePage : PhoneApplicationPage {
        private const string twitterAccessToken = "twitterAccessToken";
        private const string twitterAccessTokenSecret = "twitterAccessTokenSecret";
        private readonly SocialShareViewModel socialShareViewModel = new SocialShareViewModel();

        public SharePage() {
            InitializeComponent();
            DataContext = socialShareViewModel;
            socialShareViewModel.Message = BuildMessage();
            Loaded += MainPage_Loaded;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e) {
            if (!App.ViewModel.IsDataLoaded) {
                App.ViewModel.LoadData();
            }
        }

        private void Tweet(object sender, GestureEventArgs gestureEventArgs) {
            var twitterService = new TwitterService("qbRYCoIh1o9wG6CMiXJHfg", "5afCN0rTenjkPbfpIEh6moE0ERRUpVLunoFja5S64Ks");
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (settings.Contains(twitterAccessToken) && settings.Contains(twitterAccessTokenSecret)) {
                twitterService.AuthenticateWith(settings[twitterAccessToken] as string, settings[twitterAccessTokenSecret] as string);
                string message = BuildMessage();
                twitterService.SendTweet(message, (tweet, response) => {
                                                      if (response.StatusCode != HttpStatusCode.OK) {
                                                          settings.Remove(twitterAccessToken);
                                                          settings.Remove(twitterAccessTokenSecret);
                                                          Dispatcher.BeginInvoke(() => MessageBox.Show(response.StatusDescription));
                                                      } else {
                                                          Dispatcher.BeginInvoke(() => MessageBox.Show("Tweeted!"));
                                                      }
                                                  });
            } else {
                NavigationService.Navigate(new Uri("/OAuthPage.xaml", UriKind.Relative));
            }
        }

        private static string BuildMessage() {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            Pet pet;
            if(!settings.TryGetValue("pet", out pet)) {
                pet = new Dog();
            }
            string buildMessage = String.Format("Found {0} {1} {2} around {3} @ {4:MMM d yy} {5} {6} {7}", pet.Size, pet.Description, pet.DogOrCat, pet.FoundAround, pet.DateWhen, pet.Contact, pet.ContactMethod, settings["petUrl"]);
            return buildMessage.Replace("  ", " ");
        }

        private void PostToWall(object sender, GestureEventArgs gestureEventArgs) {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("facebookAccessToken")) {
                var client = new FacebookClient(settings["facebookAccessToken"] as string);
                var parameters = new Dictionary<string, object>();
                parameters.Add("message", BuildMessage());
                parameters.Add("message", BuildMessage());
                parameters.Add("name", "Missing pet");
                parameters.Add("privacy", new Dictionary<string, object> {{"value", "ALL_FRIENDS"}});
                client.PostCompleted += ClientOnPostCompleted;
                client.PostAsync("me/feed", parameters);
            } else {
                NavigationService.Navigate(new Uri("/FacebookOAuthPage.xaml", UriKind.Relative));
            }
        }

        private void ClientOnPostCompleted(object sender, FacebookApiEventArgs facebookApiEventArgs) {
            if (facebookApiEventArgs.Error != null) {
                Dispatcher.BeginInvoke(() => MessageBox.Show("error posting to facebook"));
            } else {
                Dispatcher.BeginInvoke(() => MessageBox.Show("posted to facebook!"));
            }
        }

        private void SubmitForKarma(object sender, GestureEventArgs gestureEventArgs) {}

        private void TextBoxGotFocus(object sender, RoutedEventArgs e) {
            socialShareViewModel.FillColor = new SolidColorBrush(Colors.White);
        }

        private void TextBoxLostFocus(object sender, RoutedEventArgs e) {
            socialShareViewModel.FillColor = new SolidColorBrush(Colors.DarkGray);
        }

    }
}