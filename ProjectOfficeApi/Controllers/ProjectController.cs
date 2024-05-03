using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        Entities.ProjectOfficeDbContext context;
        public ProjectController()
        {
            context = new Entities.ProjectOfficeDbContext();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProjects()
        {
            var list = await context.Projects
            .ToListAsync();
            return Ok(list);
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var item = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return BadRequest();
            return Ok(item);
        }
    }
}
