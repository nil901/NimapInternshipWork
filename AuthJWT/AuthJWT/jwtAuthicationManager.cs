using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AuthJWT
{
    public class jwtAuthicationManager : IjwtAuthicationManager
    { 
        private readonly IDictionary<string , string > users  = new Dictionary<string, string>
        {  { "Nilesh" , "password1"},{"Kunal" ,"Passworld2" }};
        private string key;

        public jwtAuthicationManager(string key) {

            this.key = key;
        } 
        
        public string Authenticate(string username, string passworld)
        {
            if (!users.Any(u => u.Key == username && u.Value == passworld))
            {
                return null;
                 
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey),
                     SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
              return tokenHandler.WriteToken(token); 

             


        }
    }
}
