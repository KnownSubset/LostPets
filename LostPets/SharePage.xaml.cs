using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Facebook;
using Microsoft.Phone.Controls;
using RestSharp;

namespace LostPets {
    public partial class SharePage : PhoneApplicationPage {
        public SharePage() {
            InitializeComponent();
        }

        private void Tweet(object sender, GestureEventArgs e) {
            var restClient = new RestClient();
            restClient.Authenticator = new OAuth2UriQueryParameterAuthenticator("");
            var userId = "KnownSubset";
            new RestRequest(string.Format("https://api.twitter.com/{0}/statuses/update_with_media.json", userId), Method.POST);
        }

        private void PostToWall(object sender, GestureEventArgs e) {
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

        private void SubmitForKarma(object sender, GestureEventArgs e) {}
    }
}