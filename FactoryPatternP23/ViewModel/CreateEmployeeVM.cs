﻿using FactoryPatternP23.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FactoryPatternP23.Dto
{
    public class CreateEmployeeVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        [EnumDataType(typeof(Department))]
        public Department DepartmentId { get; set; }
    }
}
