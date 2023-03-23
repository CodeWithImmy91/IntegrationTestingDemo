using IntegrationTestingDemo.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.Infra
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions option):base(option)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);

            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Id = 1,
                FirstName="Imran",
                LastName="Sayani",
                Location="BLR"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Id = 2,
                FirstName = "Sunil",
                LastName = "Sahoo",
                Location = "BLR"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
