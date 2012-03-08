using System;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Navigation;
using Hammock;
using Hammock.Authentication.OAuth;
using Microsoft.Phone.Controls;

namespace LostPets {
    public partial class OAuthPage : PhoneApplicationPage {
        public static readonly string ConsumerKey = "qbRYCoIh1o9wG6CMiXJHfg";
        public static readonly string ConsumerKeySecret = "5afCN0rTenjkPbfpIEh6moE0ERRUpVLunoFja5S64Ks";
        public static readonly string RequestTokenUri = "https://api.twitter.com/oauth/request_token";
        public static readonly string OAuthVersion = "1.0";
        public static readonly string CallbackUri = "http://www.bing.com";
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
            var credentials = new OAuthCredentials {
                                                       Type = OAuthType.RequestToken,
                                                       SignatureMethod = OAuthSignatureMethod.HmacSha1,
                                                       ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                                                       ConsumerKey = ConsumerKey,
                                                       ConsumerSecret = ConsumerKeySecret,
                                                       Version = OAuthVersion,
                                                       CallbackUrl = CallbackUri
                                                   };

            var client = new RestClient {
                                            Authority = "https://api.twitter.com/oauth",
                                            Credentials = credentials,
                                            HasElevatedPermissions = true
                                        };

            var request = new RestRequest {Path = "/request_token"};
            client.BeginRequest(request, TwitterRequestTokenCompleted);
        }

        private void TwitterRequestTokenCompleted(RestRequest request, RestResponse response, object userstate) {
            _oAuthToken = GetQueryParameter(response.Content, "oauth_token");
            _oAuthTokenSecret = GetQueryParameter(response.Content, "oauth_token_secret");
            string authorizeUrl = AuthorizeUri + "?oauth_token=" + _oAuthToken;

            if (String.IsNullOrEmpty(_oAuthToken) || String.IsNullOrEmpty(_oAuthTokenSecret)) {
                Dispatcher.BeginInvoke(() => MessageBox.Show("error calling twitter"));
                return;
            }

            Dispatcher.BeginInvoke(() => BrowserControl.Navigate(new Uri(authorizeUrl)));
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
            string requestToken = GetQueryParameter(uri, "oauth_token");
            if (requestToken != _oAuthToken) {
                MessageBox.Show("Twitter auth tokens don't match");
            }

            string requestVerifier = GetQueryParameter(uri, "oauth_verifier");

            var credentials = new OAuthCredentials {
                                                       Type = OAuthType.AccessToken,
                                                       SignatureMethod = OAuthSignatureMethod.HmacSha1,
                                                       ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                                                       ConsumerKey = ConsumerKey,
                                                       ConsumerSecret = ConsumerKeySecret,
                                                       Token = _oAuthToken,
                                                       TokenSecret = _oAuthTokenSecret,
                                                       Verifier = requestVerifier
                                                   };

            var client = new RestClient {
                                            Authority = "https://api.twitter.com/oauth",
                                            Credentials = credentials,
                                            HasElevatedPermissions = true
                                        };

            var request = new RestRequest {
                                              Path = "/access_token"
                                          };

            client.BeginRequest(request, RequestAccessTokenCompleted);
        }

        private void RequestAccessTokenCompleted(RestRequest request, RestResponse response, object userstate) {
            string accessToken = GetQueryParameter(response.Content, "oauth_token");
            string accessTokenSecret = GetQueryParameter(response.Content, "oauth_token_secret");
            if (String.IsNullOrEmpty(accessToken) || String.IsNullOrEmpty(accessTokenSecret)) {
                Dispatcher.BeginInvoke(() => MessageBox.Show(response.Content));
                return;
            }

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Remove("twitterAccessToken");
            settings.Remove("twitterAccessTokenSecret");
            settings.Add("twitterAccessToken", accessToken);
            settings.Add("twitterAccessTokenSecret", accessTokenSecret);
            settings.Save();

            Dispatcher.BeginInvoke(() => {
                                       if (NavigationService.CanGoBack) {
                                           NavigationService.GoBack();
                                       } else {
                                           NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
                                       }
                                   });
        }
    }
}