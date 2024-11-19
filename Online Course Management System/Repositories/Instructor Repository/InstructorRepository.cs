using Microsoft.EntityFrameworkCore;
using Online_Course_Management_System.Data;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Models;

namespace Online_Course_Management_System.Repositories.Instructor_Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _context;
        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(InstructorDTOPost dto)
        {
            var IsExist = await _context.Instructors.Where(x => x.Email == dto.Email).ToListAsync();
            if (IsExist.Any()) 
                return false;
            Instructor instructor = new Instructor()
            {
                Name = dto.Name,
                Email = dto.Email,
            };
            await _context.Instructors.AddAsync(instructor);
            await _context.SaveChangesAsync();

            if (dto.Courses != null && dto.Courses.Any()) 
            { 
                var validCourse = new List<Course>();
                foreach(var courses in dto.Courses)
                {
                    var courseExisted = await _context.Courses.FirstOrDefaultAsync(x => x.Name == courses.Name);
                    if (courseExisted != null)
                    {
                        validCourse.Add(courseExisted);
                    }
                    else
                    {
                        var classroom = _context.Classrooms.FirstOrDefault(x => x.Name == courses.Classroom);
                        if (classroom != null)
                        {
                            Course newInstance = new Course
                            {
                                Name = courses.Name,
                                Instructor = instructor,
                                InstructorId = instructor.Id,
                                Description = courses.Description,
                                Classroom = classroom,
                                ClassroomId = classroom.Id
                            };
                            validCourse.Add(newInstance);
                        }
                        else
                        {
                            throw new Exception("This Classroom is not existed");
                        }
                    }
                }
                instructor.Courses = validCourse;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null) return false;
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<InstructorDTOGet>> GetAll()
        {
            return await _context.Instructors.
                Include(x => x.Courses).
                ThenInclude(x => x.Students).
                Include(x => x.Courses).
                ThenInclude(x => x.Classroom).
                Select(x => new InstructorDTOGet
                {
                    Name = x.Name,
                    Email = x.Email,
                    Courses = x.Courses.Select(x => new CourseDTOGet
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Classroom = new ClassroomDTOGet
                        {
                            Capacity = x.Classroom.Capacity,
                            Name = x.Classroom.Name,
                            Location = x.Classroom.Location,
                        },
                        Students = x.Students.Select(x => new StudentDTOGet
                        {
                            Name = x.Name,
                            Email = x.Email,
                            EnrollmentDate = x.EnrollmentDate,
                        }).ToList()
                        
                    }).ToList(),
                }).ToListAsync();
        }

        public async Task<InstructorDTOGet> GetById(int id)
        {
            var instructor = await _context.Instructors.
                Where(x => x.Id == id).
                Include(x => x.Courses).
                ThenInclude(x => x.Students).
                Include(x => x.Courses).
                ThenInclude(x => x.Classroom).
                Select(x => new InstructorDTOGet
                {
                    Name = x.Name,
                    Email = x.Email,
                    Courses = x.Courses.Select(x => new CourseDTOGet
                    {
                        Name = x.Name,
                        Description = x.Description,
                        Classroom = new ClassroomDTOGet
                        {
                            Capacity = x.Classroom.Capacity,
                            Name = x.Classroom.Name,
                            Location = x.Classroom.Location,
                        },
                        Students = x.Students.Select(x => new StudentDTOGet
                        {
                            Name = x.Name,
                            Email = x.Email,
                            EnrollmentDate = x.EnrollmentDate,
                        }).ToList()

                    }).ToList(),
                }).FirstOrDefaultAsync();
            if (instructor == null)
                return null;
            return instructor;
        }

        public async Task<bool> Update(InstructorDTOPost dto, int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null) return false;

            instructor.Name = dto.Name;
            instructor.Email = dto.Email;
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();

            if (dto.Courses != null && dto.Courses.Any()) 
            { 
                var validCourse = new List<Course>();
                foreach(var courses in dto.Courses)
                {
                    var courseExisted = await _context.Courses.FirstOrDefaultAsync(x => x.Name == courses.Name);
                    if (courseExisted != null)
                    {
                        validCourse.Add(courseExisted);
                    }
                    else
                    {
                        var classroom = _context.Classrooms.FirstOrDefault(x => x.Name == courses.Name);
                        if (classroom != null)
                        {
                            Course newInstance = new Course
                            {
                                Name = courses.Name,
                                Instructor = instructor,
                                InstructorId = instructor.Id,
                                Description = courses.Description,
                                Classroom = classroom,
                                ClassroomId = classroom.Id
                            };
                            validCourse.Add(newInstance);
                        }
                        else
                        {
                            throw new Exception("This Classroom is not existed");
                        }
                    }
                }
                instructor.Courses = validCourse;
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
