using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
             = string.Empty;

        public DateTime CreationTime { get; set; }
             = DateTime.UtcNow;

        // related tables
        public IEnumerable<Employee>? Employees { get; set; }
    }

}