using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<tblCustomers> tblCustomers { get; set; }
        public DbSet<tblCity> tblCities { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
