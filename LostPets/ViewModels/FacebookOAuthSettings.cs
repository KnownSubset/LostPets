namespace LostPets.ViewModels {
    public class FacebookOAuthSettings : OAuthApplicationSettings {
        private static string oAuthToken = null;
        private static string oAuthTokenSecret = null;
        public string ConsumerKey {
            get { return "324495074265566"; }
        }

        public string ConsumerKeySecret {
            get { return "4bba366017cc46f630a5c59cdb977fe6"; }
        }

        public string RequestTokenUri {
            get { return "https://www.facebook.com/dialog/oauth/"; }
        }

        public string OAuthVersion {
            get { return "2.0"; }
        }

        public string CallbackUri {
            get { return "http://www.lostpets.com/AuthorizeCallback"; }
        }

        public string AuthorizeUri {
            get { return "https://api.twitter.com/oauth/authorize"; }
        }

        public string AccessTokenUri {
            get { return "https://api.twitter.com/oauth/access_token"; }
        }

        public string OAuthToken {
            get { return oAuthToken; }
            set { oAuthToken = value; }
        }

        public string OAuthTokenSecret {
            get { return oAuthTokenSecret; }
            set { oAuthTokenSecret = value; }
        }
    }
}