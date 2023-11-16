namespace _30HillsProject.API.Core
{
    public class JWTSettings
    {
        public int Minutes { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
    }
}
