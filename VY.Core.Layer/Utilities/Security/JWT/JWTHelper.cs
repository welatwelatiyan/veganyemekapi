using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VY.Core.Layer.Utilities.Security.JWT.Encryption;


namespace VY.Core.Layer.Utilities.Security.JWT
{
    public class JWTHelper : ITokenHelper
    {
        public IConfiguration configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JWTHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            _tokenOptions = configuration.GetSection(key: "TokenOptions")
                                         .Get<TokenOptions>();
        }
        public AccessToken CreateToken(List<Claim> claims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialHelper.CreateSigningCredentials(securityKey);
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var jwt = CreateJwtSecurityToken(tokenOptions: _tokenOptions, claims, signingCredentials: signingCredentials);
            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = JwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration.ToUniversalTime()

            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, IEnumerable<Claim> claims, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: claims,
                signingCredentials: signingCredentials
                );
            return jwt;
        }
    }
}
