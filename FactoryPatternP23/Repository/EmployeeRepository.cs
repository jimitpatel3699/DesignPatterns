using Microsoft.EntityFrameworkCore;
using FactoryPatternP23.Interface;
using FactoryPatternP23.Model;

namespace FactoryPatternP23.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.Where(emp => emp.Status == true).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id && emp.Status == true);
        }

        public async Task AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            _context.SaveChanges();
        }
        public async Task DeleteEmployee(Employee employee)
        {
            var employeeEntity = await GetEmployeeById(employee.Id);
            if (employeeEntity != null)
            {
                employeeEntity.Status = false;
                _context.Employees.Update(employeeEntity);
                _context.SaveChanges();
            }
        }
    }
}
