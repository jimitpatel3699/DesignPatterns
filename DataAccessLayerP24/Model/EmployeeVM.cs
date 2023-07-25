using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerP24.Data;

namespace DataAccessLayerP24.Model
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
