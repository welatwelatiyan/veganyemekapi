using System.Security.Claims;

namespace VY.Core.Layer.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(List<Claim> claims);
    }
}
