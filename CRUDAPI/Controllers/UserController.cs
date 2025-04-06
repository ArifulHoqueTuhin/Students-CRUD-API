using CRUDAPI.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly CodeFirstApproach2Context dbData;

        public UserController(CodeFirstApproach2Context DbData)
        {
            dbData = DbData;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(User user)
        {


            if (ModelState.IsValid)
            {
                await dbData.Users.AddAsync(user);
                await dbData.SaveChangesAsync();
                return Ok(new { message = "User registered successfully" });


            }

            else
            {
                return Ok(new { message = " Invalid User registered" });


            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var UserData = await dbData.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefaultAsync();

            if (UserData != null)
            {
                return Ok(new { message = "User login successfully" });
            }
            else
            {
                return Ok(new { message = "User login failed" });
            }
        }
    }
}
