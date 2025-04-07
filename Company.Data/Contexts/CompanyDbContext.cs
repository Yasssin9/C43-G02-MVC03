using Company.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Contexts
{
    public class CompanyDbContext : IdentityDbContext<ApplicationUser>
    {

        public CompanyDbContext()
        {
            
        }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=CompanyMVC;trusted_connection=true;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<BaseEntity>().HasQueryFilter(x=>!x.IsDeleted);
            base.OnModelCreating(modelBuilder);
            

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }


    }
}
