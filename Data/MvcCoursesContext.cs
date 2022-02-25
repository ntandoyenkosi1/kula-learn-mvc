#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KulaMVC.Models;

    public class MvcCoursesContext : DbContext
    {
        public MvcCoursesContext (DbContextOptions<MvcCoursesContext> options)
            : base(options)
        {
        }

        public DbSet<KulaMVC.Models.Course> Course { get; set; }

        public DbSet<KulaMVC.Models.Module> Module { get; set; }
    }
