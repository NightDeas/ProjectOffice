using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOfficeApi.Entities;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Entities.DbContextProjectOffice context;

        public EmployeeController()
        {
            context = new DbContextProjectOffice();
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
