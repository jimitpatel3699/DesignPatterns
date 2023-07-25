using FactoryPatternP23.Model;
using Practical23_API.ViewModel;

namespace FactoryPatternP23.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> AddEmployee(Employee employee);
        Employee DeleteEmployee(Employee employee);
        Employee UpdateEmployee(UpdateVM employee);

    }
}
