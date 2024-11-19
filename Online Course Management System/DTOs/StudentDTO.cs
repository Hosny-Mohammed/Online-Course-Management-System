using Online_Course_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.DTOs
{
    public class StudentDTOGet
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }
        //relation
        public ICollection<CourseDTOGet>? Courses { get; set; }
    }
    public class StudentDTOPost
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }
        //relation
        public ICollection<string>? Courses { get; set; }
    }
}
