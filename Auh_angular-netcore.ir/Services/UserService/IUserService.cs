using System.Collections.Generic;
using Auh_angular_netcore.Entities;
using Auh_angular_netcore.ir.ViewModel;

namespace Auh_angular_netcore.Services.UserService
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();

        User Login(User login);
        void UpdateUser(User user);
        User GetUserById(int id);
    }
}
