using AutoMapper;
using DataAccessLayerP26.Data;
using DataAccessLayerP26.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP26.Repository
{
    public class CommandRepository :ICommand
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public CommandRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<EmployeeAddVM> AddEmployee(EmployeeAddVM request)
        {
            Employee employee = _mapper.Map<EmployeeAddVM, Employee>(request);

            if (employee != null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            var employeeViewModel = _mapper.Map<Employee, EmployeeAddVM>(employee);
            return new List<EmployeeAddVM> { employeeViewModel };
        }
        public EmployeeAddVM DeleteEmployee(int? id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                emp.Isdeleted = true;
                _context.Employees.Update(emp);
                _context.SaveChanges();

            }
            return _mapper.Map<Employee, EmployeeAddVM>(emp);
        }
        public EmployeeVM UpdateEmployee(EmployeeVM employee)
        {
            var existingEmployee = _context.Employees.Where(x => x.Isdeleted == false).FirstOrDefault(x => x.Id == employee.Id);

            if (existingEmployee != null)
            {
                _mapper.Map(employee, existingEmployee);
                _context.SaveChanges();
            }
            return _mapper.Map<Employee, EmployeeVM>(existingEmployee);
        }
    }
}
