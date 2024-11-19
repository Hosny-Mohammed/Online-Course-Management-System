using Online_Course_Management_System.DTOs;

namespace Online_Course_Management_System.Repositories.Course_Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDTOGet>> GetAll();
        Task<CourseDTOGet> GetById(int id);
        Task Add(CourseDTOPost dto);
        Task<bool> Update(CourseDTOPost dto, int id);
        Task<bool> Delete(int id);
    }
}
