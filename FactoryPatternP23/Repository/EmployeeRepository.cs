using Microsoft.EntityFrameworkCore;
using FactoryPatternP23.Interface;
using FactoryPatternP23.Model;
using FactoryPatternP23.Dto;
using Practical23_API.ViewModel;
using AutoMapper;

namespace FactoryPatternP23.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.Where(emp => emp.Isdeleted == false);
        }
        public Employee GetEmployeeById(int id)
        {
            return  _context.Employees.FirstOrDefault(emp => emp.Id == id && emp.Isdeleted == false);
        }
        public IEnumerable<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return _context.Employees;
        }
        public Employee DeleteEmployee(Employee employee)
        {
            var employeeEntity =  GetEmployeeById(employee.Id);
            if (employeeEntity != null)
            {
                employeeEntity.Isdeleted = true;
                _context.Employees.Update(employeeEntity);
                _context.SaveChanges();
            }
            return employeeEntity;
        }

        public Employee UpdateEmployee(UpdateVM employee)
        {
            var existingEmployee = _context.Employees.Where(x => x.Isdeleted == false).FirstOrDefault(x => x.Id == employee.Id);

            if (existingEmployee != null)
            {
                _mapper.Map(employee, existingEmployee);
                _context.SaveChanges();
            }
            return existingEmployee;
        }
    }
}
