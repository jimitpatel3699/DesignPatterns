using FactoryPatternP23.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FactoryPatternP23.Dto
{
    public class UpdateEmployeeVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        [EnumDataType(typeof(Department))]
        public Department DepartmentId { get; set; }
        [ValidateNever]
        public bool Isdeleted { get; set; } = false;
    }
}
