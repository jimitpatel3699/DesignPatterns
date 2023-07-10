using AutoMapper;
using DataAccessLayerP22.Data;
using DataAccessLayerP22.Handler;
using DataAccessLayerP22.Model;
using DataAccessLayerP22.Singleton;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP22.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationContext _context =SingletonClass.GetDbInstance();
        private readonly Logger _logger = SingletonClass.GetLoggerInstance();
        private readonly IMapper _mapper;
        public EmployeeRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IEnumerable<EmployeeAddVM> AddEmployee(EmployeeAddVM request)
        {
            Employee employee = _mapper.Map<EmployeeAddVM, Employee>(request);

            if (employee != null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                _logger.Log("New Employees added in DB");
            }

            var employeeViewModels = GetAllEmployees().Cast<EmployeeAddVM>();
            return employeeViewModels;
        }
    

        public EmployeeAddVM DeleteEmployee(int? id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                 emp.Isdeleted=true;
                _context.Employees.Update(emp);
                _context.SaveChanges();
                _logger.Log("Employees deleted in DB");

            }
            return _mapper.Map<Employee, EmployeeAddVM>(emp);
        }

        public IEnumerable<EmployeeALLVM> GetAllEmployees()
        {
            var employees = _context.Employees.Where(x=>x.Isdeleted==false).ToList();
            var employeeViewModels = _mapper.Map<List<Employee>, List<EmployeeALLVM>>(employees);
            return employeeViewModels;
        }

        public EmployeeALLVM GetSingleEmployee(int? id)
        {
            var emp = _context.Employees.Where(x => x.Isdeleted == false).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Employee, EmployeeALLVM>(emp);
        }

        public EmployeeViewModel UpdateEmployee(EmployeeViewModel employee)
        {
            var existingEmployee = _context.Employees.Where(x => x.Isdeleted == false).FirstOrDefault(x => x.Id == employee.Id);

            if (existingEmployee != null)
            {
                _mapper.Map(employee, existingEmployee);
                _context.SaveChanges();
                _logger.Log("Employees data updated in DB");
            }
            return _mapper.Map<Employee, EmployeeViewModel>(existingEmployee);
        }
    }
}
