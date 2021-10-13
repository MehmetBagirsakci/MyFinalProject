namespace Core.Utilities.Security.JWT
{
    //Helper class. Bir tokenin tutması gereken optionsları tutar.
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
