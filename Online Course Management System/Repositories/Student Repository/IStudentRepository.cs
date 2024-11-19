using Online_Course_Management_System.DTOs;

namespace Online_Course_Management_System.Repositories.Student_Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDTOGet>> GetAll();
        Task<StudentDTOGet> GetById(int id);
        Task<bool> Add(StudentDTOPost dto);
        Task<bool> Update(StudentDTOPost dto, int id);
        Task<bool> Delete(int id);
    }
}
