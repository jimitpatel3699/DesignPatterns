using AutoMapper;
using DataAccessLayerP22.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP22.Handler
{
    public class AutomapperHandler:Profile
    {
        public AutomapperHandler() 
        {
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Employee,EmployeeAddVM>().ReverseMap();
            CreateMap<Employee, EmployeeALLVM>().ReverseMap();
        }
    }
}
