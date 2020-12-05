using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auh_angular_netcore.Config;
using Auh_angular_netcore.DataLayer.Context;
using Auh_angular_netcore.Entities;
using Auh_angular_netcore.ir.ViewModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auh_angular_netcore.Services.UserService
{
    public class UserService : IUserService
    {


        private readonly AppSettings _appSettings;
        private OghabContext _context;

        public UserService(IOptions<AppSettings> appSettings, OghabContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }
        //public UserService(IOptions<AppSettings> appSettings,)
        //{
        //    _appSettings = appSettings.Value;
        //}

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new ClaimsIdentity();
            claims.AddClaims(new[]
            {
                new Claim("AccessAllUser", user.AccessAllUser.ToString())
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(User login)
        {
            return _context.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
        }

        public void UpdateUser(User user)
        {
            var get = _context.Users.Find(user.Id);
            _context.Users.Update(get);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            User user = _context.Users.Find(id);
            return user;
        }
    }
}