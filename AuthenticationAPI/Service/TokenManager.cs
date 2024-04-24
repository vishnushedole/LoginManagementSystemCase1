using LoginManagement.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAPI.Service
{
    public static class TokenManager
    {
        const string UserId = "UserId";
        const string RoleName = "RoleName";

        public static string GenerateWebToken(User model, AppSettings settings)
        {
            //Create a Claims Set 
            var claimsSet = new List<Claim>
            {
                new Claim(UserId, model.UserId.ToString())
            };
            //Create an Identity based on the Claims set 
            var userIdentity = new ClaimsIdentity(claimsSet);

            var keyBytes = Encoding.UTF8.GetBytes(settings.AppSecret);
            var signInCredentials = new SigningCredentials(
                key: new SymmetricSecurityKey(keyBytes),
                algorithm: settings.Algorithm
                );
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = userIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signInCredentials,
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var preToken = handler.CreateToken(descriptor);
            var writeableToken = handler.WriteToken(preToken);
            return writeableToken;
        }

        public static User GetUserFromToken(
            string token,
            AppSettings settings,
            IUserServiceAsync service)
        {
            var keyBytes = Encoding.UTF8.GetBytes(settings.AppSecret);
            var signInKey = new SymmetricSecurityKey(keyBytes);
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = signInKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            handler.ValidateToken(
                token: token,
                validationParameters: validationParameters,
                validatedToken: out SecurityToken validatedToken
                );
            var outputToken = validatedToken as JwtSecurityToken;
            var userId = outputToken.Claims.FirstOrDefault(c => c.Type == UserId)?.Value;
            //discard variable is denoted with underscore _ 
            _ = outputToken.Claims.FirstOrDefault(c => c.Type == RoleName)?.Value;

            var user = service.GetUserDetails(Convert.ToInt32(userId)).Result;
            return user;
        }
    }
}
