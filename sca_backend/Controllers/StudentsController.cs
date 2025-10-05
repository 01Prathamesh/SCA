// Controllers/StudentsController.cs
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDAL _studentDAL;

        public StudentsController(StudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }

        // GET: api/Students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = _studentDAL.GetAllStudents();
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _studentDAL.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: api/Students
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {
            _studentDAL.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _studentDAL.UpdateStudent(student);

            return NoContent();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentDAL.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentDAL.DeleteStudent(id);

            return NoContent();
        }
    }
}
