using Ders20.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ders20
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Posts> Post { get; set; }

        public DbSet<Users> Users { get; set; }

    }
}


