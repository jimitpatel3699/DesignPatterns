using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerP24.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DataAccessLayerP24.Model
{
    public class Employee
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
        public Status Status { get; set; }
        [ValidateNever]
        public bool Isdeleted { get; set; } = false;
        [Required]
        [EnumDataType(typeof(Department))]
        public Department DepartmentId { get; set; }
    }
}
