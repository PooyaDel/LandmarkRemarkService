using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandmarkRemarkService.Database;
using LandmarkRemarkService.Models;

namespace LandmarkRemarkService.WorkerClasses
{
    public class UserLogin : IUserLogin
    {
        public UserLogin()
        {

        }

        /// <summary>
        /// Retrieve user data with the given credentials and returns true on success.
        /// </summary>
        /// <param name="login">login DTO</param>
        /// <returns>false if not found or invalid username/password, otherwise true.</returns>
        public async Task<UserViewModel> Login(UserLoginModel login)
        {
            await using var context = new LandmarkDbContext();
            var user = context.UserContextInfo.FirstOrDefault(x =>
                x.UserId == login.UserId && x.Password == login.Password);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
