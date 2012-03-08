namespace LostPets.ViewModels {
    internal interface OAuthApplicationSettings {
        string ConsumerKey { get; }
        string ConsumerKeySecret { get; }
        string RequestTokenUri { get; }
        string OAuthVersion { get; }
        string CallbackUri { get; }
        string AuthorizeUri { get; }
        string AccessTokenUri { get; }
        string OAuthToken { get; set; }
        string OAuthTokenSecret { get; set; }
    }
}