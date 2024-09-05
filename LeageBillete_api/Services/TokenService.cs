using LeageBillete_api.Data;
using LeageBillete_api.Model.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LeageBillete_api.Services
{
    public class TokenService
    {
        private const int ExpirationMinutes = 30;
        private readonly IOptions<TokensSettings> _tokensSettings;
        private readonly ApplicationDbContext _context;
        public TokenService(IOptions<TokensSettings> tokensSettings, ApplicationDbContext context)
        {
            _tokensSettings = tokensSettings;
            _context = context;
        }

        public string CreateToken(IdentityUser user, string role)
        {
            try
            {
                DateTime expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
                var Jwtoken = CreateJwtToken(CreateClaims(user, role),
                                                CreateSigningCredentials(),
                                                expiration);
                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(Jwtoken);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
            DateTime expiration) => new JwtSecurityToken(
                                                        _tokensSettings.Value.Issuer,
                                                        _tokensSettings.Value.Issuer,
                                                        claims,
                                                        expires: expiration,
                                                        signingCredentials: credentials);

        private List<Claim> CreateClaims(IdentityUser user, string role)
        {
            var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheApiWithAuth"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, role)
                };

            return claims;
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokensSettings.Value.Key)),
                SecurityAlgorithms.HmacSha256);
        }

        /*public RefreshToken GenerateRefreshToken(string ipAddress)
         {
             var refreshToken = new RefreshToken
             {
                 Token = getUniqueToken(),
                 Expires = DateTime.UtcNow.AddDays(7),
                 Created = DateTime.UtcNow,
                 CreatedByIp = ipAddress
             };

             return refreshToken;
         }

         private string getUniqueToken()
         {
             var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

             var tokenIsUnique = !_context.Users.Any(u => u.RefreshTokens.Any(t => t.Token == token));

             if (!tokenIsUnique)
                 return getUniqueToken();

             return token;
         }
        */

    }
}
