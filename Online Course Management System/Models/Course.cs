using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_Management_System.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        //relation
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public int? InstructorId {  get; set; }
        [ForeignKey("InstructorId")]
        public Instructor? Instructor { get; set; }
        public int? ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        public Classroom? Classroom { get; set; }

    }
}
