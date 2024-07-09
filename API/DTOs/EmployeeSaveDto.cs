using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class EmployeeSaveDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string? ReasonForLeaving { get; set; }
    }
}