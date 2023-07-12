using FactoryPatternP23.Model;

namespace FactoryPatternP23.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployeeById(int id);
        public Task AddEmployee(Employee employee);
        public Task DeleteEmployee(Employee employee);
    }
}
