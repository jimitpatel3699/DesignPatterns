using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerP24.Data;

namespace DataAccessLayerP24.Model
{
    public class EmployeeALLVM
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
        [Required]
        [EnumDataType(typeof(Status))]
        public string Status { get; set; }
        [Required]
        [EnumDataType(typeof(Department))]
        public string DepartmentId { get; set; }
    }
}
