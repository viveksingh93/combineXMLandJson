using combineJSONandXML.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace combineXMLandJson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> _student = new List<Student>();
        public StudentController() {

            for (int i = 1; i <= 9; i++)
            {
                _student.Add(new Student()
                {
                    Id = i,
                    Name = "stu" +1,
                    Roll = "100" + 1,
                });
            }
        }
        
        [HttpGet("get.{format}"), FormatFilter]
        public IEnumerable<Student> Get()
        {
            return _student;
        }

        
        [HttpPost("post.{format}"), FormatFilter]
        public Student Post([FromBody] Student student)
        {
            if (ModelState.IsValid) return student;
            return null;
        }
    }
}
