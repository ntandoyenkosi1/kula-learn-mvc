using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KulaLearnMVC.Models;

namespace KulaLearnMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<KulaLearnMVC.Models.Course> Course { get; set; }
    public DbSet<KulaLearnMVC.Models.Module> Module { get; set; }
}
