using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Infrastructure.Persistence.DummyData;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Color = PortfolioApp.Domain.Entities.Color;

namespace PortfolioApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHasher<User> passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Color> Colors { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.Code)
                .HasMaxLength(12);
            modelBuilder.Entity<Item>()
            .Property(e => e.Name)
            .HasMaxLength(200);


            foreach (var item in DummyColors.Get())
            {
                modelBuilder.Entity<Color>().HasData(item);
            }
            foreach (var item in DummyItems.Get())
            {
                modelBuilder.Entity<Item>().HasData(item);
            }
            foreach (var item in DummyRoles.Get())
            {
                modelBuilder.Entity<Role>().HasData(item);
            }

            foreach (var item in DummyUsers.Get())
            {
                item.Password = _passwordHasher.HashPassword(item, item.Password);
                modelBuilder.Entity<User>().HasData(item);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortfolioDatabase;Integrated Security=True;Pooling=False");
        }
    }
}
