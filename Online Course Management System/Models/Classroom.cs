using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, Range(0,int.MaxValue)]
        public int Capacity { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; } = string.Empty;
        //relation
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
