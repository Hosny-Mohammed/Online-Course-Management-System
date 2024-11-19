using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Repositories.Instructor_Repository;
using Online_Course_Management_System.Repositories.Student_Repository;

namespace Online_Course_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _repo;
        public InstructorController(IInstructorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDTOGet>>> GetAll()
        {
            var instructors = await _repo.GetAll();
            return Ok(instructors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDTOGet>> GetAll(int id)
        {
            var instructor = await _repo.GetById(id);
            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }
        [HttpPost]
        public async Task<IActionResult> Add(InstructorDTOPost dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var isExist = await _repo.Add(dto);
            if (!isExist)
                return BadRequest("This email is used before");
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] InstructorDTOPost dto, int id)
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
