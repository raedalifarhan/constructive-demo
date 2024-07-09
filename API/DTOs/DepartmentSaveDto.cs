using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class DepartmentSaveDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}