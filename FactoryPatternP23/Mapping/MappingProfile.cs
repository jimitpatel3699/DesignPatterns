﻿using AutoMapper;
using FactoryPatternP23.Dto;
using FactoryPatternP23.Model;

namespace FactoryPatternP23.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();

            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();

            CreateMap<Employee, EmployeeDtoHourBonus>();

        }
    }
}
