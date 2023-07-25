using Microsoft.EntityFrameworkCore;
using MediatorPatternP25.Models;

namespace MediatorPatternP25.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {            
        }
        public DbSet<Employee> Employees { get; set; }        
    }
}
