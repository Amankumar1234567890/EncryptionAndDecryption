using EncryptionAndDecryption.Model;
using EncryptionAndDecryption.StudentRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAndDecryption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent? _student;
        public StudentController(IStudent student)  
        { 
            _student = student;
        }
        [HttpPost]
        public IActionResult InsertStudentData(Student stu)
        {
            var data=_student?.InsertStudentData(stu);
            return Ok(data);
        }
        [HttpGet]
        public IActionResult DisplayStudentData()
        {
            var data = _student?.GetAllStudentData();
            return Ok(data);

        }
    }
}
