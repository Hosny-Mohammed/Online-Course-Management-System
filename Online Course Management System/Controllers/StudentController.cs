using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Repositories.Student_Repository;

namespace Online_Course_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTOGet>>> GetAll()
        {
            var students = await _repo.GetAll();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTOGet>> GetAll(int id)
        {
            var student = await _repo.GetById(id);
            if(student == null) 
                return NotFound();

            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Add(StudentDTOPost dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var isExist = await _repo.Add(dto);
            if (!isExist)
                return BadRequest("This email is used before");
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] StudentDTOPost dto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            bool k = await _repo.Update(dto, id);
            if (!k)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            bool k = await _repo.Delete(id);
            if (!k)
                return NotFound();
            return Ok();
        }
    }
}
