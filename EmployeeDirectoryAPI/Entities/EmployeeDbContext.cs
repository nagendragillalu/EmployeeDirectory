using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Entities
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkills> EmployeeSkills { get; set; }
        public DbSet<DepartmentDetails> DepartmentDetails { get; set; }
        public DbSet<TeamDetails> TeamDetails { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<EmployeeBiography> EmployeeBiographies { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<EventsDetails> EventsDetails { get; set; }
        public DbSet<BirthdayMessages> BirthdayMessages { get; set; }
    }
}
