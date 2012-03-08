using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Net;
using Facebook;
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
            if (settings.Contains("twitterAccessToken") && settings.Contains("twitterAccessTokenSecret")) {
                Action<OAuthAccessToken, TwitterResponse> accessTokenAction = (oAuthAccessToken, twitterResponse) => twitterService.AuthenticateWith(oAuthAccessToken.Token, oAuthAccessToken.TokenSecret);
                Action<OAuthRequestToken, TwitterResponse> requestTokenAction = (oAuthRequestToken, response) => twitterService.GetAccessToken(oAuthRequestToken, accessTokenAction);
                twitterService.GetRequestToken(requestTokenAction);

                twitterService.ListTweetsOnHomeTimeline((tweets, response) => {
                                                            if (response.StatusCode != HttpStatusCode.OK) {
                                                                throw new Exception(response.StatusCode.ToString());
                                                            }
                                                        });
                twitterService.SendTweet("Tweeting with #tweetsharp for #wp7", (tweet, response) => {
                                                                                   if (response.StatusCode != HttpStatusCode.OK) {
                                                                                       throw new Exception(response.StatusCode.ToString());
                                                                                   }
                                                                               });
            } else {
                NavigationService.Navigate(new Uri("/OAuthPage.xaml", UriKind.Relative));
            }
        }

        private void PostToWall(object sender, GestureEventArgs gestureEventArgs) {
            var client = new FacebookClient("");
            var parameters = new Dictionary<string, object>();
            parameters.Add("message", "Olav is testing Facebook C# SDK");
            parameters.Add("link", "http://facebooksdk.codeplex.com/");
            parameters.Add("picture", "http://download.codeplex.com/Project/Download/FileDownload.aspx?ProjectName=facebooksdk&DownloadId=170794&Build=17672");
            parameters.Add("name", "Facebook C# SDK");
            parameters.Add("caption", "http://facebooksdk.codeplex.com/");
            parameters.Add("description", "The Facebook C# SDK helps .Net developers build web, desktop, Silverlight, and Windows Phone 7 applications that integrate with Facebook.");
            parameters.Add("privacy", new Dictionary<string, object> {{"value", "ALL_FRIENDS"}});
            client.PostAsync("me/feed", parameters);
        }

        private void SubmitForKarma(object sender, GestureEventArgs gestureEventArgs) {}
    }
}