using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_Management_System.DTOs;
using Online_Course_Management_System.Repositories.Classroom_Repository;

namespace Online_Course_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomRepository _repo;
        public ClassroomController(IClassroomRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassroomDTOGet>>> GetAll()
        {
            var classrooms = await _repo.GetAll();
            return Ok(classrooms);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomDTOGet>> GetAll(int id)
        {
            var classroom = await _repo.GetById(id);
            if(classroom == null) 
                return NotFound();

            return Ok(classroom);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ClassroomDTOPost dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _repo.Add(dto);

            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ClassroomDTOPost dto, int id)
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
