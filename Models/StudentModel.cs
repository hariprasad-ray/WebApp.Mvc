using System.ComponentModel.DataAnnotations;

namespace WebApp.Mvc.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string? Name { get; set; }
        [Required]
        public string? Section { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
