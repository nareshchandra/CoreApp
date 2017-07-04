using Microsoft.EntityFrameworkCore;
using AuthService.Entity;
using AuthService.Utility;

namespace AuthService.Repository
{
    //Build all the projects
    //Selecting this project StartUp project.
    // Enable-Migrations
    //Add-Migration "AuthServiceDB"
    //Update-Database "migration filename in Migration database"
    public class AuthServiceDBContext : DbContext
    {
        private readonly string connectionString;

        public AuthServiceDBContext(IUtility Utility) : base()
        {
            connectionString = Utility.GetConnectionString();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(i => i.UserRoles)
                .WithOne(i => i.User);

            modelBuilder.Entity<Role>()
                .HasMany(i => i.UserRoles)
                .WithOne(i => i.Role);
        }
    }

}
