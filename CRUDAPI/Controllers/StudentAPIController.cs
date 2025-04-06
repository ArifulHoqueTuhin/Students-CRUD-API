using CRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly CodeFirstApproach2Context dbData;

        public StudentAPIController(CodeFirstApproach2Context DbData) 
        {
            dbData = DbData;
        }


        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent ()
        {
            var StuData = await dbData.Students.ToListAsync();
            return Ok(StuData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var Student = await dbData.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
             return Student;
        }


        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await dbData.Students.AddAsync(std);
            await dbData.SaveChangesAsync();
            return Ok(std);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
           

            if (id != std.Id)
            {
                return BadRequest();
            }
            
            dbData.Entry(std).State = EntityState.Modified;
            await dbData.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var DlStudent = await dbData.Students.FindAsync(id);

            if (DlStudent == null)
            {
                return NotFound();
            }
            
            dbData.Students.Remove(DlStudent);
            await dbData.SaveChangesAsync();
            return Ok();
        }
    }
}
