using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.DateTime)]
        public DateTime JoiningDate { get; set; }

        [Required]
        public Department DepartmentId { get; set; }

        public bool Status { get; set; } = false;
    }
}
