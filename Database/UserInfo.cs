using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandmarkRemarkService.Database
{
    public class UserInfo
    {
        /// <summary>
        /// User Id / Primary key, identity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string UserId { get; set; }
        /// <summary>
        /// User name appearing on UI
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// The data notation is to mark a foreign key rather a shallow that for Entity Framework.
        /// 
        /// </summary>
        [ForeignKey("UserId")]

        public List<MapLandmark> MapLandmarks { get; } = new List<MapLandmark>();
    }
}