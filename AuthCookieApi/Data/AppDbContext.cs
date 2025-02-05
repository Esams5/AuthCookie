using Microsoft.EntityFrameworkCore;

namespace AuthCookieApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=authcookiedb;user=root;password=samuel5723",
            ServerVersion.AutoDetect("server=localhost;database=authcookiedb;user=root;password=samuel5723"));
    }
}