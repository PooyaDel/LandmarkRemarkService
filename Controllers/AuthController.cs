using System.Threading.Tasks;
using LandmarkRemarkService.Database;
using LandmarkRemarkService.Models;
using LandmarkRemarkService.WorkerClasses;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemarkService.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserLogin _userLogin;

        public AuthController(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }

        //TODO: remove this class and use proper auth!
        /// <summary>
        /// This is just a mocked loginModel process in order to display how th UI reacts, no proper authentication implementation intended here.
        /// </summary>
        /// <param name="userLoginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<UserViewModel> Post([FromBody]UserLoginModel userLoginModel)
        {
            return await _userLogin.Login(userLoginModel);
        }
    }
}
