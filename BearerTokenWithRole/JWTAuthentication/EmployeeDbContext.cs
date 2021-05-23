using JWTAuthentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication
{
    public class EmployeeDbContext:IdentityDbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Employee> employee { get; set; }
    }
}
