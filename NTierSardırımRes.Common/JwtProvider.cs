using Microsoft.IdentityModel.Tokens;
using NTierSardırımRes.Entities.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTierSardırımRes.Common
{
    public static class JwtProvider
    {

        //JWT oluşturan metodun tanımlanması.
        public static string GetJWT(AppUser user)
        {
            //Claims

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };

            //key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("332fbc79d04ad7e0df7b16a3cb042179768a794f1f425d0fb946ced1fe21327e"));


            //credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //expires
            var expires = DateTime.Now.AddDays(365D);

            //token
            var token = new JwtSecurityToken(
                issuer: "https://localhost:7157", //Api katmanı tarafından oluşturulacak.
                audience: "https://localhost:7157",//Api katmanı tarafından kullanılacak.
                claims: claims,
                expires: expires,
                signingCredentials: creds
                );

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }

}
