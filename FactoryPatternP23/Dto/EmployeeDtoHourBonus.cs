﻿using FactoryPatternP23.Model;

namespace FactoryPatternP23.Dto
{
    public class EmployeeDtoHourBonus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public DateTime JoiningDate { get; set; }
        public Department DepartmentId { get; set; }
        public int Hours { get; set; }
        public decimal Bouns { get; set; }
    }
}
