using Microsoft.IdentityModel.Tokens;

namespace VY.Core.Layer.Utilities.Security.JWT.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, algorithm: SecurityAlgorithms
                                                                .HmacSha256Signature);
        }
    }
}
