using AutoMapper;
using DataAccessLayerP24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP24.Handler
{
    public class AutomapperHandler : Profile
    {
        public AutomapperHandler()
        {
            CreateMap<EmployeeVM, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeAddVM>().ReverseMap();
            CreateMap<Employee, EmployeeALLVM>().ReverseMap();
            CreateMap<EmployeeALLVM, EmployeeAddVM>().ReverseMap();
        }
    }
}
