using DataAccessLayerP26.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP26.Model
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [EnumDataType(typeof(Department))]
        public Department DepartmentId { get; set; }
    }
}
