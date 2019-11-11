using System.Threading.Tasks;
using LandmarkRemarkService.Database;
using LandmarkRemarkService.Models;

namespace LandmarkRemarkService.WorkerClasses
{
    public interface IUserLogin
    {
        Task<UserViewModel> Login(UserLoginModel login);
    }
}