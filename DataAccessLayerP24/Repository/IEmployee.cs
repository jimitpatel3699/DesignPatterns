using DataAccessLayerP24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP24.Repository
{
    public interface IEmployee
    {
        IEnumerable<EmployeeALLVM> GetAllEmployees();
        EmployeeALLVM GetSingleEmployee(int? id);
        IEnumerable<EmployeeAddVM> AddEmployee(EmployeeAddVM request);
        EmployeeVM UpdateEmployee(EmployeeVM employee);
        EmployeeAddVM DeleteEmployee(int? id);
    }
}
