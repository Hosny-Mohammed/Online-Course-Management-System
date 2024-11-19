using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Repositories.Classroom_Repository;
using Online_Course_Management_System.Repositories.Course_Repository;

namespace Online_Course_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repo;
        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTOGet>>> GetAll()
        {
            var courses = await _repo.GetAll();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTOGet>> GetAll(int id)
        {
            var course = await _repo.GetById(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CourseDTOPost dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _repo.Add(dto);

            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CourseDTOPost dto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            bool k = await _repo.Update(dto, id);
            if (!k)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool k = await _repo.Delete(id);
            if (!k)
                return NotFound();
            return Ok();
        }
    }
}
