namespace LostPets.ViewModels {
    class TwitterOAuthSettings : OAuthApplicationSettings {
        private static string oAuthToken = null;
        private static string oAuthTokenSecret = null;
        public string ConsumerKey {
            get { return "qbRYCoIh1o9wG6CMiXJHfg"; }
        }

        public string ConsumerKeySecret {
            get { return "5afCN0rTenjkPbfpIEh6moE0ERRUpVLunoFja5S64Ks"; }
        }

        public string RequestTokenUri {
            get { return "https://api.twitter.com/oauth/request_token"; }
        }

        public string OAuthVersion {
            get { return "1.0"; }
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