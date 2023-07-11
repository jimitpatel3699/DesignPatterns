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
    public class QueryRepository:IQuery
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public QueryRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
