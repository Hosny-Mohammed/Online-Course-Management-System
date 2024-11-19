using Microsoft.EntityFrameworkCore;
using Online_Course_Management_System.Data;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Models;

namespace Online_Course_Management_System.Repositories.Student_Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(StudentDTOPost dto)
        {
            var studentt = await _context.Students.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (studentt != null) 
                return false;
            Student student = new Student();
            student.Name = dto.Name;
            student.Email = dto.Email;
            student.EnrollmentDate = dto.EnrollmentDate;
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            if(dto.Courses != null && dto.Courses.Any())
            {
                var validCourses = await _context.Courses.Where(x => dto.Courses.Contains(x.Name)).ToListAsync();
                if (validCourses.Any() && validCourses != null)
                {
                    student.Courses = validCourses;
                    await _context.SaveChangesAsync();
                }
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StudentDTOGet>> GetAll()
        {
            return await _context.Students.
                Include(x => x.Courses).
                ThenInclude(x => x.Classroom).
                Include(x => x.Courses).
                ThenInclude(x => x.Instructor).
                Select(x => new StudentDTOGet
                {
                    Name = x.Name,
                    Email = x.Email,
                    EnrollmentDate = x.EnrollmentDate,
                    Courses = x.Courses.Select(x => new CourseDTOGet
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Classroom = new ClassroomDTOGet
                        {
                            Name = x.Classroom.Name,
                            Capacity = x.Classroom.Capacity,
                            Location = x.Classroom.Location
                        }
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<StudentDTOGet> GetById(int id)
        {
            var student = await _context.Students.
                Where(x => x.Id == id).
                Include(x => x.Courses).
                ThenInclude(x => x.Classroom).
                Include(x => x.Courses).
                ThenInclude(x => x.Instructor).
                Select(x => new StudentDTOGet
                {
                    Name = x.Name,
                    Email = x.Email,
                    EnrollmentDate = x.EnrollmentDate,
                    Courses = x.Courses.Select(x => new CourseDTOGet
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Classroom = new ClassroomDTOGet
                        {
                            Name = x.Classroom.Name,
                            Capacity = x.Classroom.Capacity,
                            Location = x.Classroom.Location
                        }
                    }).ToList()
                }).FirstOrDefaultAsync();
            if (student == null)
                return null;
            return student;
        }

        public async Task<bool> Update(StudentDTOPost dto, int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;
            student.Name = dto.Name;
            student.Email = dto.Email;
            student.EnrollmentDate = dto.EnrollmentDate;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            if(dto.Courses !=  null && dto.Courses.Any())
            {
                var validCourse = await _context.Courses.Where(x => dto.Courses.Contains(x.Name)).ToListAsync();
                if (validCourse != null && validCourse.Any())
                {
                    student.Courses = validCourse;
                    await _context.SaveChangesAsync();
                } 
            }
            return true;
        }
    }
}
