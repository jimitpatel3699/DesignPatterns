using AutoMapper;
using FactoryPatternP23.Dto;
using FactoryPatternP23.Model;
using Practical23_API.ViewModel;

namespace FactoryPatternP23.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeVM, Employee>();
            CreateMap<Employee, EmployeeVM>();

            CreateMap<CreateEmployeeVM, Employee>();
            CreateMap<Employee, CreateEmployeeVM>();

            CreateMap<UpdateEmployeeVM, Employee>();
            CreateMap<Employee, UpdateEmployeeVM>();

            CreateMap<Employee, EmployeeHourBonusVM>();
            CreateMap<Employee,UpdateVM>().ReverseMap();
        }
    }
}
