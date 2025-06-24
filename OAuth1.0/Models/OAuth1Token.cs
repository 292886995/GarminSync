namespace OAuth1._0
{
    /// <summary>
    /// OAuth1 Token 信息
    /// </summary>
    public class OAuth1Token
    {
        public string OAuthToken { get; set; }
        public string OAuthTokenSecret { get; set; }
        public string? MfaToken { get; set; }
        public DateTime? MfaExpirationTimestamp { get; set; }
        public string? Domain { get; set; }
    }
}
