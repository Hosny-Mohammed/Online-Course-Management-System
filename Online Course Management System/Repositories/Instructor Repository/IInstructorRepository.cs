using Online_Course_Management_System.DTOs;

namespace Online_Course_Management_System.Repositories.Instructor_Repository
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<InstructorDTOGet>> GetAll();
        Task<InstructorDTOGet> GetById(int id);
        Task<bool> Add(InstructorDTOPost dto);
        Task<bool> Update(InstructorDTOPost dto, int id);
        Task<bool> Delete(int id);
    }
}
