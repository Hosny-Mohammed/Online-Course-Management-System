using Online_Course_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.DTOs
{
    public class CourseDTOGet
    {
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public ICollection<StudentDTOGet>? Students { get; set; } 

        public InstructorDTOGet? Instructor { get; set; }
        public ClassroomDTOGet? Classroom { get; set; }
    }
    public class CourseDTOPost
    {
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public ICollection<string>? Students { get; set; }

        public string? Instructor { get; set; }
        public string? Classroom { get; set; }
    }
}
