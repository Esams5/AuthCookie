using Microsoft.EntityFrameworkCore;

namespace AuthCookieApi.Data
{
    public class AppDbContext : DbContext
    {
        // Construtor que aceita DbContextOptions<AppDbContext>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        // Remova o método OnConfiguring, pois a configuração será feita no Program.cs
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? SessionId { get; set; }
    }
}