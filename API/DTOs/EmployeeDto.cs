namespace API.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set;}
        public string Name { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string ReasonForLeaving { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
    }
}