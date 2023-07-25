using FactoryPatternP23.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Practical23_API.ViewModel
{
    public class UpdateVM
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
    }
}
