using Microsoft.EntityFrameworkCore;
using Online_Course_Management_System.Data;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Models;

namespace Online_Course_Management_System.Repositories.Course_Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context) { _context = context; }

        public async Task Add(CourseDTOPost dto)
        {
            Course course = new Course() 
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            if (dto.Classroom != null && dto.Classroom != "")
            {
                var validClassroom = await _context.Classrooms.FirstOrDefaultAsync(x => x.Name == dto.Classroom);
                if (validClassroom != null) 
                {
                    course.ClassroomId = validClassroom.Id;
                    course.Classroom = validClassroom;
                    await _context.SaveChangesAsync();
                }
            }

            if (dto.Instructor != null && dto.Instructor != "")
            {
                var validInstructor = await _context.Instructors.FirstOrDefaultAsync(x => x.Name == dto.Instructor);
                if (validInstructor != null)
                {
                    course.InstructorId = validInstructor.Id;
                    course.Instructor = validInstructor;
                    await _context.SaveChangesAsync();
                }
            }

            if (dto.Students != null && dto.Students.Any())
            {
                var validStudents = await _context.Students.Where(x => dto.Students.Contains(x.Name)).ToListAsync();

                if (validStudents != null && validStudents.Any())
                {
                    course.Students = validStudents;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course == null) return false;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseDTOGet>> GetAll()
        {
            return await _context.Courses.
                Include(x => x.Instructor).
                Include(x => x.Classroom).
                Include(x => x.Students).
                Select(x => new CourseDTOGet
                {
                    Name = x.Name,
                    Description = x.Description,
                    Classroom = new ClassroomDTOGet
                    {
                        Name = x.Classroom.Name,
                        Capacity = x.Classroom.Capacity,
                        Location = x.Classroom.Location,
                    },
                    Instructor = new InstructorDTOGet 
                    {
                        Name = x.Instructor.Name,
                        Email = x.Instructor.Email,
                    },
                    Students = x.Students.Select(x => new StudentDTOGet
                    {
                        Name = x.Name,
                        Email = x.Email,
                        EnrollmentDate = x.EnrollmentDate,
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<CourseDTOGet> GetById(int id)
        {
            var course = await _context.Courses.
                Where(x => x.Id == id).
                Include(x => x.Instructor).
                Include(x => x.Classroom).
                Include(x => x.Students).
                Select(x => new CourseDTOGet
                {
                    Name = x.Name,
                    Description = x.Description,
                    Classroom = new ClassroomDTOGet
                    {
                        Name = x.Classroom.Name,
                        Capacity = x.Classroom.Capacity,
                        Location = x.Classroom.Location,
                    },
                    Instructor = new InstructorDTOGet
                    {
                        Name = x.Instructor.Name,
                        Email = x.Instructor.Email,
                    },
                    Students = x.Students.Select(x => new StudentDTOGet
                    {
                        Name = x.Name,
                        Email = x.Email,
                        EnrollmentDate = x.EnrollmentDate,
                    }).ToList()
                }).FirstOrDefaultAsync();
            if (course == null)
                return null;
            return course;
        }

        public async Task<bool> Update(CourseDTOPost dto, int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;
            course.Name = dto.Name;
            course.Description = dto.Description;
            
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            if (dto.Classroom != null && dto.Classroom != "")
            {
                var validClassroom = await _context.Classrooms.FirstOrDefaultAsync(x => x.Name == dto.Classroom);
                if (validClassroom != null)
                {
                    course.ClassroomId = validClassroom.Id;
                    course.Classroom = validClassroom;
                    await _context.SaveChangesAsync();
                }
            }

            if (dto.Instructor != null && dto.Instructor != "")
            {
                var validInstructor = await _context.Instructors.FirstOrDefaultAsync(x => x.Name == dto.Classroom);
                if (validInstructor != null)
                {
                    course.InstructorId = validInstructor.Id;
                    course.Instructor = validInstructor;
                    await _context.SaveChangesAsync();
                }
            }

            if (dto.Students != null && dto.Students.Any())
            {
                var validStudents = await _context.Students.Where(x => dto.Students.Contains(x.Name)).ToListAsync();

                if (validStudents != null && validStudents.Any())
                {
                    course.Students = validStudents;
                    await _context.SaveChangesAsync();
                }
            }

            return true;
        }
    }
}
