using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ProjectOffice.DataBase.Entities.DbContextProjectOffice context;

        public EmployeeController()
        {
            context = new ProjectOffice.DataBase.Entities.DbContextProjectOffice();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEmployees()
        {
            var list = await context.Employees
            .ToListAsync();
            return Ok(list);
        }
    }
}
