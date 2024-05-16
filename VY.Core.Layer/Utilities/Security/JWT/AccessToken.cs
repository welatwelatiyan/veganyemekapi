using VY.Core.Layer.Entity;

namespace VY.Core.Layer.Utilities.Security.JWT
{
    public class AccessToken:IDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
