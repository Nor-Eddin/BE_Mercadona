namespace BE_Mercadona.DTOs
{
    public class AuthenticationResponse
    {
        #region Properties
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        #endregion
    }
}
