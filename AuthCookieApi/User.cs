namespace AuthCookieApi
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? SessionId { get; set; } // Use string? para permitir NULL
    }
}