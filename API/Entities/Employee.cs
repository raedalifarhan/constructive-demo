using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime JoiningDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LeavingDate { get; set; }
        
        [MaxLength(500)]
        public string? ReasonForLeaving { get; set; }
        
        public DateTime CreationTime { get; set; }
             = DateTime.UtcNow;

        // related tables
        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}