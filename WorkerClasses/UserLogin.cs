using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using LandmarkRemarkService.Database;
using LandmarkRemarkService.Models;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Logging;

namespace LandmarkRemarkService.WorkerClasses
{

    //TODO: remove this class and use proper auth!
    public class UserLogin : IUserLogin
    {
        private readonly ILogger<UserLogin> _logger;
        /// <summary>
        /// DI for logger (log4net)
        /// </summary>
        /// <param name="logger"></param>
        public UserLogin(ILogger<UserLogin> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieve user data with the given credentials and returns true on success.
        /// </summary>
        /// <param name="login">login DTO</param>
        /// <returns>null if not found or invalid username/password, otherwise UserViewModel.</returns>
        public async Task<UserViewModel> Login(UserLoginModel login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.UserId) || string.IsNullOrEmpty(login.Password) )
                {
                    throw new InvalidOperationException("User id or password are not valid.");
                }
                await using var context = new LandmarkDbContext();
                var user = context.UserContextInfo.FirstOrDefault(x => x.UserId == login.UserId && x.Password == login.Password);


                if (user == null)
                {
                    throw new InvalidOperationException("User id or password are not valid.");
                }

                return new UserViewModel()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email
                };

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error logging in. Method: {Method}, time: {time}", nameof(Login), DateTime.Now);
                throw;
            }
        }
    }
}
