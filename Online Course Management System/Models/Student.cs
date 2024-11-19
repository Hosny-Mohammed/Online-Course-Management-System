using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }
        //relation
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
