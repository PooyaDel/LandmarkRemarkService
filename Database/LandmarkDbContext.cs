using Microsoft.EntityFrameworkCore;

namespace LandmarkRemarkService.Database
{
    public class LandmarkDbContext : DbContext
    {
        /// <summary>
        /// User information such as ID, email.
        /// </summary>
        public DbSet<UserInfo> UserContextInfo { get; set; }
        /// <summary>
        /// Information about map points and the the note.
        /// </summary>
        public DbSet<MapLandmark> MapLandmark { get; set; }
        /// <summary>
        /// Provides location of the database file to be configured by Entity Framework.
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=LandmarkRemark.db");

        /// <summary>
        /// This seeds 2 default users for DEMO/TEST purposes!
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(new UserInfo
            {
                UserId = "guest1",
                Email = "GuestUser1@GuestUser1.com",
                Password  = "1",
                Name = "Guest User1",
            }, new UserInfo
            {
                UserId = "guest2",
                Email = "GuestUser2@GuestUser2.com",
                Password  = "2",
                Name = "Guest User2",
            });

        }

    }
}
