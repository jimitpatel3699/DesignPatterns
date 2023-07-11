using AutoMapper;
using DataAccessLayerP24.Data;
using DataAccessLayerP24.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP24.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(ApplicationContext context,IMapper mapper)
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

        public IEnumerable<EmployeeALLVM> GetAllEmployees()
        {
            var employees = _context.Employees.Where(x => x.Isdeleted == false).ToList();
            var employeeViewModels = _mapper.Map<List<Employee>, List<EmployeeALLVM>>(employees);
            return employeeViewModels;
        }

        public EmployeeALLVM GetSingleEmployee(int? id)
        {
            var emp = _context.Employees.Where(x => x.Isdeleted == false).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Employee, EmployeeALLVM>(emp);
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
