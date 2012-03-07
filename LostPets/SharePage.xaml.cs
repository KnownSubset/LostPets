using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Facebook;
using Microsoft.Phone.Controls;
using RestSharp;
using TweetSharp;

namespace LostPets {
    public partial class SharePage : PhoneApplicationPage {
        public SharePage() {
            InitializeComponent();
        }

        private void Tweet(object sender, System.Windows.Input.GestureEventArgs gestureEventArgs) {
            var twitterService = new TwitterService("consumerKey", "consumerSecret");
            twitterService.AuthenticateWith("accessToken", "accessTokenSecret");
            twitterService.SendTweet("Tweeting with #tweetsharp for #wp7", (tweet, response) => {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            });
        }

        private void PostToWall(object sender, System.Windows.Input.GestureEventArgs gestureEventArgs) {
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

        private void SubmitForKarma(object sender, System.Windows.Input.GestureEventArgs gestureEventArgs) {}
    }
}