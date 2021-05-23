using Microsoft.EntityFrameworkCore;
using MobileAppAPI.Models;

namespace MobileAppAPI
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {
                
        }
        
        public DbSet<Employee> employee { get; set; }
    }
}
