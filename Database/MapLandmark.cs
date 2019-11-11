using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandmarkRemarkService.Database
{
    public class MapLandmark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public double Lat { get; set; }
        [Required]
        public double Lng { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}