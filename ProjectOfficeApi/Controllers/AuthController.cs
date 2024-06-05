using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProjectOffice.DataBase.Entities;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string login, [FromQuery]string password)
        {
            Context context = new();
            var user = context.Users.FirstOrDefault(x=> x.Login == login && x.Password == password);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
