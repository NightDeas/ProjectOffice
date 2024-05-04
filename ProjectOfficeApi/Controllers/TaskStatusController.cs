using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly Entities.DbContextProjectOffice context;
        public TaskStatusController()
        {
            context = new Entities.DbContextProjectOffice();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTaskStatuses()
        {
            var list = await context.TaskStatuses
            .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTaskStatus(int id)
        {
            var taskStatus = await context.TaskStatuses
            .FirstOrDefaultAsync(x => x.Type == id);
            if (taskStatus == null)
                return NotFound();
            return Ok(taskStatus);
        }
    }
}
