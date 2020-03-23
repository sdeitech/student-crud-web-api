using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System;

namespace StudentCoreApp.Controllers
{
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private IStudentService _studentService;
        private readonly ILogger<StudentAPIController> _exceptionLogger;
        public StudentAPIController(IStudentService studentService, ILogger<StudentAPIController> exceptionLogger)
        {
            _studentService = studentService;
            _exceptionLogger = exceptionLogger;
        }

        [HttpGet]
        [Route("api/StudentAPI/GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var student = _studentService.GetAllStudents();
                return Ok(student);
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return StatusCode(500, "Intrenal Server Error.");
            }
        }

        // GET: api/StudentAPI/GetStudentDetail/5
        [HttpGet("{id}")]
        [Route("api/StudentAPI/GetStudentDetail/{id}")]
        public IActionResult GetStudentDetail(int id)
        {
            try
            {
                StudentDTO student = _studentService.GetStudentDetail(id);
                if (student == null)
                {
                    return NotFound("The Student record couldn't be found.");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return StatusCode(500, "Intrenal Server Error.");
            }
        }

        [HttpPost]
        [Route("api/StudentAPI/SaveStudent")]
        public IActionResult SaveStudent([FromBody] StudentDTO student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student is null.");
                }
                bool isStudentInformationSave = _studentService.AddStudent(student);
                string returnMessage = isStudentInformationSave == true ? "Student added successfully." : "There is an error while adding student.";
                return Ok(returnMessage);
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return StatusCode(500, "Intrenal Server Error.");
            }
        }

        [HttpPut]
        [Route("api/StudentAPI/UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] StudentDTO student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student is null.");
                }
                StudentDTO getStudentDetail = _studentService.GetStudentDetail(student.StudentId);
                if (getStudentDetail == null)
                {
                    return NotFound("The Student record couldn't be found.");
                }
                bool isStudentInformationUpdate = _studentService.UpdateStudent(student);
                string returnMessage = isStudentInformationUpdate == true ? "Student updated successfully." : "There is an error while updating student.";
                return Ok(returnMessage);
            }
            catch(Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return StatusCode(500, "Intrenal Server Error.");
            }
        }

        [HttpDelete("{id}")]
        [Route("api/StudentAPI/DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                StudentDTO student = _studentService.GetStudentDetail(id);
                if (student == null)
                {
                    return NotFound("The Student record couldn't be found.");
                }

                bool isStudentDeleted = _studentService.DeleteStudent(student);
                string returnMessage = isStudentDeleted == true ? "Student deleted successfully." : "There is an error while deleting student.";
                return Ok(returnMessage);
            }
            catch(Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return StatusCode(500, "Intrenal Server Error.");
            }
            
        }
    }
}