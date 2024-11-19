﻿using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        //relation
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
