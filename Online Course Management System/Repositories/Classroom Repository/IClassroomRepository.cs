using Online_Course_Management_System.DTOs;

namespace Online_Course_Management_System.Repositories.Classroom_Repository
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<ClassroomDTOGet>> GetAll();
        Task<ClassroomDTOGet> GetById(int id);
        Task Add(ClassroomDTOPost dto);
        Task<bool> Update(ClassroomDTOPost dto, int id);
        Task<bool> Delete(int id);
    }
}
