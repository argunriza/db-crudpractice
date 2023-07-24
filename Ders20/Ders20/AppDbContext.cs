using Ders20.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ders20
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user1 = new Users
            {
                Id = 1, Username = "Riza", Password = "12345", CreatedAt = DateTime.Now, Email = "tempmail@gmail.com",
                CreatedBy = 1
            };

            modelBuilder.Entity<Users>().HasData(user1);

            List<Posts> posts = new List<Posts>
            {
                new(){Id = 1, Title ="Post1", Content = "Post1", CreatedAt = DateTime.Now, CreatedBy = 1},
                new(){Id = 2, Title ="Post2", Content = "Post2", CreatedAt = DateTime.Now, CreatedBy = 1},
                new(){Id = 3, Title ="Post3", Content = "Post3", CreatedAt = DateTime.Now, CreatedBy = 1}
            };

            modelBuilder.Entity<Posts>().HasData(posts);
        }

    }
}


