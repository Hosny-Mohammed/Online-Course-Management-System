using Online_Course_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.DTOs
{
    public class ClassroomDTOGet
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; } = string.Empty;
        //relation
        public ICollection<CourseDTOGet> Courses { get; set; } = new List<CourseDTOGet>();
    }
    public class ClassroomDTOPost
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; } = string.Empty;
        //relation
        public ICollection<string>? Courses { get; set; }
    }
}
