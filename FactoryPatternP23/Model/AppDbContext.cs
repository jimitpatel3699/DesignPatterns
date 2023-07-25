
using Microsoft.EntityFrameworkCore;

namespace FactoryPatternP23.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
