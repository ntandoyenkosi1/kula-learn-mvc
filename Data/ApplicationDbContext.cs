using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KulaMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace KulaMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)  
    {  
        base.OnModelCreating(builder);  
        this.SeedUsers(builder);  
        this.SeedRoles(builder);
        this.SeedUserRoles(builder);  
    }
    private void SeedUsers(ModelBuilder builder)  
        {  
            IdentityUser user = new IdentityUser()  
            {  
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",  
                UserName = "Admin",  
                Email = "admin@gmail.com",  
                LockoutEnabled = false,  
                PhoneNumber = "1234567890"  
            };  
  
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();  
            passwordHasher.HashPassword(user, "Admin*123");  
            builder.Entity<IdentityUser>().HasData(user);  
        }  
  
        private void SeedRoles(ModelBuilder builder)  
        {  
            builder.Entity<IdentityRole>().HasData(  
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },  
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Instructor", ConcurrencyStamp = "2", NormalizedName = "Instructor" },
                new IdentityRole() { Id = "de7013f0-8790-5417-abh9-e324f91r7442", Name = "Student", ConcurrencyStamp = "3", NormalizedName = "Student" }  
                );  
        }
        private void SeedUserRoles(ModelBuilder builder)  
        {  
            builder.Entity<IdentityUserRole<string>>().HasData(  
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }  
            );
        }
    public DbSet<KulaMVC.Models.Course> Course { get; set; }
    public DbSet<KulaMVC.Models.Module> Module { get; set; }
    public DbSet<KulaMVC.Models.User> User { get; set; }

}
