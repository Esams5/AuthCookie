using Microsoft.EntityFrameworkCore;

namespace AuthCookieApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=auth;user=SamuelEsdras;password=05072003",
                ServerVersion.AutoDetect("server=localhost;database=auth;user=SamuelEsdras;password=05072003"));
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
    }
}