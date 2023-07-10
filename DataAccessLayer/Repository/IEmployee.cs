using DataAccessLayerP22.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP22.Repository
{
    public interface IEmployee
    {
        IEnumerable<EmployeeALLVM> GetAllEmployees();
        EmployeeALLVM GetSingleEmployee(int? id);
        IEnumerable<EmployeeAddVM> AddEmployee(EmployeeAddVM request);
        EmployeeViewModel UpdateEmployee(EmployeeViewModel employee);
        EmployeeAddVM DeleteEmployee(int? id);
    }
}
