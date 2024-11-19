using Online_Course_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.DTOs
{
    public class InstructorDTOGet
    {
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        //relation
        public ICollection<CourseDTOGet>? Courses { get; set; }
    }
    public class InstructorDTOPost
    {
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        //relation
        public ICollection<CourseDTOPost>? Courses { get; set; }
    }
}
