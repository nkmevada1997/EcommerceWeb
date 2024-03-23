using EcommerceWeb.Repository.Models;
using EcommerceWeb.Utility.Encode;
using EcommerceWeb.Utility.Enum;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Repository.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasOne(x => x.State).WithMany().HasForeignKey(x => x.StateId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>().HasOne(c => c.Country).WithMany().HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>().HasOne(c => c.State).WithMany().HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>().HasOne(c => c.City).WithMany().HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<State>().HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Supplier>().HasOne(c => c.Country).WithMany().HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Supplier>().HasOne(c => c.State).WithMany().HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Supplier>().HasOne(c => c.City).WithMany().HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasOne(u => u.Customer).WithMany().HasForeignKey(u => u.CustomerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasOne(u => u.Supplier).WithMany().HasForeignKey(u => u.SupplierId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@gmail.com",
                Password = EncodeBase.EncodeBase64("Admin@123"),
                UserName = "Admin",
                UserType = UserType.Admin,
                CanLogin = true,
                CreatedDate = DateTime.UtcNow,
                IsActive = false,
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
