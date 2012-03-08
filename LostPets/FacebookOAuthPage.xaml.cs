using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using Facebook;
using LostPets.ViewModels;
using Microsoft.Phone.Controls;

namespace LostPets {
    public partial class FacebookOAuthPage : PhoneApplicationPage {
        public static readonly FacebookOAuthSettings facebookOAuthSettings = new FacebookOAuthSettings();

        public FacebookOAuthPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            GetFacebookAccessToken();
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsIndeterminate = true;
        }

        private void GetFacebookAccessToken() {
            var extendedPermissions = new[] {"publish_stream", "offline_access"};
            var oauth = new FacebookOAuthClient {AppId = facebookOAuthSettings.ConsumerKey};
            var parameters = new Dictionary<string, object> {
                                                                {"response_type", "token"},
                                                                {"display", "popup"}
                                                            };
            if (extendedPermissions != null && extendedPermissions.Length > 0) {
                var scope = new StringBuilder();
                scope.Append(string.Join(",", extendedPermissions));
                parameters["scope"] = scope.ToString();
            }
            BrowserControl.Navigate(oauth.GetLoginUrl(parameters));
        }

        private void BrowserControlNavigated(object sender, NavigationEventArgs e) {
            ProgressBar.IsIndeterminate = false;
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void BrowserControlNavigating(object sender, NavigatingEventArgs e) {
            ProgressBar.IsIndeterminate = true;
            ProgressBar.Visibility = Visibility.Visible;

            FacebookOAuthResult result;
            if (FacebookOAuthResult.TryParse(e.Uri, out result)) {
                if (result.IsSuccess) {
                    IsolatedStorageSettings isolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings;
                    isolatedStorageSettings.Remove("facebookAccessToken");
                    isolatedStorageSettings.Add("facebookAccessToken", result.AccessToken);
                    isolatedStorageSettings.Save();
                    NavigationService.GoBack();
                }
            }
        }
    }
}