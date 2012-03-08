using System;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Navigation;
using Hammock;
using Microsoft.Phone.Controls;
using TweetSharp;

namespace LostPets {
    public partial class OAuthPage : PhoneApplicationPage {
        public static readonly string ConsumerKey = "qbRYCoIh1o9wG6CMiXJHfg";
        public static readonly string ConsumerKeySecret = "5afCN0rTenjkPbfpIEh6moE0ERRUpVLunoFja5S64Ks";
        public static readonly string RequestTokenUri = "https://api.twitter.com/oauth/request_token";
        public static readonly string OAuthVersion = "1.0";
        public static readonly string CallbackUri = "http://www.lostpets.com/AuthorizeCallback";
        public static readonly string AuthorizeUri = "https://api.twitter.com/oauth/authorize";
        public static readonly string AccessTokenUri = "https://api.twitter.com/oauth/access_token";

        private string _oAuthToken;
        private string _oAuthTokenSecret;

        public OAuthPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            GetTwitterToken();
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsIndeterminate = true;
        }

        private void GetTwitterToken() {
            // Pass your credentials to the service
            var service = new TwitterService(ConsumerKey, ConsumerKeySecret);

            // Step 1 - Retrieve an OAuth Request Token
            Action<OAuthRequestToken, TwitterResponse> requestTokenAction = (oAuthRequestToken, response) => {
                                                                                Uri uri = service.GetAuthorizationUri(oAuthRequestToken);
                                                                                Dispatcher.BeginInvoke(() => BrowserControl.Navigate(uri));
                                                                            };
            service.GetRequestToken(requestTokenAction);


            // Step 3 - Exchange the Request Token for an Access Token
            //string verifier = "123456"; // <-- This is input into your application by your user
            //OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);
        }


        private static string GetQueryParameter(string input, string parameterName) {
            foreach (string item in input.Split('&')) {
                string[] parts = item.Split('=');
                if (parts[0] == parameterName) {
                    return parts[1];
                }
            }
            return String.Empty;
        }

        private void BrowserControlNavigated(object sender, NavigationEventArgs e) {
            ProgressBar.IsIndeterminate = false;
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void BrowserControlNavigating(object sender, NavigatingEventArgs e) {
            ProgressBar.IsIndeterminate = true;
            ProgressBar.Visibility = Visibility.Visible;

            if (e.Uri.AbsoluteUri.CompareTo("https://api.twitter.com/oauth/authorize") == 0) {
                ProgressBar.IsIndeterminate = true;
                ProgressBar.Visibility = Visibility.Visible;
            }

            if (!e.Uri.AbsoluteUri.Contains(CallbackUri)) {
                return;
            }

            e.Cancel = true;

            string[] arguments = e.Uri.AbsoluteUri.Split('?');
            if (arguments.Length < 1) {
                return;
            }

            GetAccessToken(arguments[1]);
        }

        private void GetAccessToken(string uri) {
            string oauth_verifier = GetQueryParameter(uri, "oauth_verifier");
            string oauth_token = GetQueryParameter(uri, "oauth_token");
            var requestToken = new OAuthRequestToken {Token = oauth_token};

            // Step 3 - Exchange the Request Token for an Access Token
            var service = new TwitterService(ConsumerKey, ConsumerKeySecret);
            Action<TwitterUser, TwitterResponse> action;
            Action<OAuthAccessToken, TwitterResponse> authenicateAction = (oAuthAccessToken, twitterResponse) => {
                                 service.AuthenticateWith(oAuthAccessToken.Token, oAuthAccessToken.TokenSecret);
                                 action = (twitterUser, response) => {
                                              IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                                              settings.Remove("twitterAccessToken");
                                              settings.Remove("twitterAccessTokenSecret");
                                              settings.Add("twitterAccessToken", oAuthAccessToken.Token);
                                              settings.Add("twitterAccessTokenSecret", oAuthAccessToken.TokenSecret);
                                              settings.Save();
                                              NavigationService.GoBack();
                                          };
                                 service.VerifyCredentials(action);
                             };
            service.GetAccessToken(requestToken, oauth_verifier, authenicateAction);
        }
    }
}