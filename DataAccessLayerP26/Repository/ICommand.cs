using DataAccessLayerP26.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP26.Repository
{
    public interface ICommand
    {
        IEnumerable<EmployeeAddVM> AddEmployee(EmployeeAddVM request);
        EmployeeVM UpdateEmployee(EmployeeVM employee);
        EmployeeAddVM DeleteEmployee(int? id);
    }
}
