using MediatorPatternP25.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatorPatternP25.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; } 
        [Required]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        [ValidateNever]
        public Department DepartmentId { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
