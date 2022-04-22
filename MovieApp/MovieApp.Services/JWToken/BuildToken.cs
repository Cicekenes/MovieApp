using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MovieApp.Services.JWToken
{
    public class BuildToken
    {
        public string CreateToken() // Token oluşturma metodu
        {
            var bytes = Encoding.UTF8.GetBytes("movieappsecurity"); // program cs'deki konfigürasyon'daki kelimedir
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes); // Key kullanmamız gerekiyor
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Keyi çağırma işlemi ve algoritmayı belirleme
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",audience: "http://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials); //notbefore şimdiden itibaren, expires kaç dakika geçerli olduğudur
            JwtSecurityTokenHandler handler= new JwtSecurityTokenHandler();
            return handler.WriteToken(token); // token nesnesinden gelen tokeni yaz
        }
    }
}
