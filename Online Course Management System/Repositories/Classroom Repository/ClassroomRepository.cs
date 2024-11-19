using Microsoft.EntityFrameworkCore;
using Online_Course_Management_System.Data;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Models;

namespace Online_Course_Management_System.Repositories.Classroom_Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _context;
        public ClassroomRepository(AppDbContext context) { _context = context; }

        public async Task Add(ClassroomDTOPost dto)
        {
            Classroom classroom = new Classroom() 
            {
                Name = dto.Name,
                Capacity = dto.Capacity,
                Location = dto.Location,
            };
            await _context.Classrooms.AddAsync(classroom);
            await _context.SaveChangesAsync();

            if (dto.Courses != null && dto.Courses.Any()) 
            {
                var validCourse = await _context.Courses.Where(x => dto.Courses.Contains(x.Name)).ToListAsync();
                if (validCourse != null && validCourse.Any())
                {
                    classroom.Courses = validCourse;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if(classroom == null)
                return false;
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClassroomDTOGet>> GetAll()
        {
            return await _context.Classrooms.
                Include(x => x.Courses).
                ThenInclude(x => x.Instructor).
                Select(x => new ClassroomDTOGet
                {
                    Name = x.Name,
                    Capacity = x.Capacity,
                    Location = x.Location,
                    Courses = x.Courses.Select(x => new CourseDTOGet
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Instructor = new InstructorDTOGet
                        {
                            Name = x.Instructor.Name,
                            Email = x.Instructor.Email
                        }
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<ClassroomDTOGet> GetById(int id)
        {
            var classroom = await _context.Classrooms.
                Where(x => x.Id == id).
                Include(x => x.Courses).
                ThenInclude(x => x.Instructor).
                Select(x => new ClassroomDTOGet
                {
                    Name = x.Name,
                    Capacity = x.Capacity,
                    Location = x.Location,
                    Courses = x.Courses.Select(x => new CourseDTOGet
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Instructor = new InstructorDTOGet
                        {
                            Name = x.Instructor.Name,
                            Email = x.Instructor.Email
                        }
                    }).ToList()
                }).FirstOrDefaultAsync();
            if (classroom == null)
                return null;
            return classroom;
        }

        public async Task<bool> Update(ClassroomDTOPost dto, int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null) return false;

            classroom.Name = dto.Name;
            classroom.Capacity = dto.Capacity;
            classroom.Location = dto.Location;

            _context.Classrooms.Update(classroom);
            await _context.SaveChangesAsync();

            if(dto.Courses != null && dto.Courses.Any())
            {
                var validCourse = await _context.Courses.Where(x => dto.Courses.Contains(x.Name)).ToListAsync();
                if (validCourse != null)
                {
                    classroom.Courses = validCourse;
                    await _context.SaveChangesAsync();
                }
            }
            return true;
        }
    }
}
