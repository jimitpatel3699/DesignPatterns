using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FactoryPatternP23.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Required]
        [EnumDataType(typeof(Department))]
        public Department DepartmentId { get; set; }
        [ValidateNever]
        public bool Isdeleted { get; set; } = false;
    }
}
