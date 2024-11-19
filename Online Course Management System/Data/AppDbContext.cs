using Microsoft.EntityFrameworkCore;
using Online_Course_Management_System.Models;

namespace Online_Course_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(x => x.Email).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
