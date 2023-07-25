using DataAccessLayerP24.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP24.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext() : base()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=SF-CPU-597;Initial Catalog=EmployeeManagementP24;Integrated Security=True;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
