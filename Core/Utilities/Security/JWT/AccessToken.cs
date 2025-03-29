namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public required string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
