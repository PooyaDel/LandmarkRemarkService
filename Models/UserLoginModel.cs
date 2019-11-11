using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemarkService.Models
{
    /// <summary>
    /// User login info sent from UI.
    /// </summary>
    public class UserLoginModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
