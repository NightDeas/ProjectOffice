using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        Entities.ProjectOfficeDbContext _context;
        IMapper _map;
        public TaskController()
        {
            _context = new Entities.ProjectOfficeDbContext();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTasks()
        {
            var list = await _context.Projects
            .ToListAsync();
            return Ok(list);
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var item = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return BadRequest();
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(TaskRequest request)
        {
            Task task = _map.Map<TaskRequest, Task>(request);
            if (task == null)
                return BadRequest();
            return Ok();
        }

    }

    public class TaskRequest
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string FullTitle { get; set; }

        public string ShortTitle { get; set; }

        public string Description { get; set; }

        public Guid ExecutiveEmployeedId { get; set; }

        public int StatusId { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public DateTime? DeletedTime { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? StartActualTime { get; set; }

        public DateTime? FinishActualTime { get; set; }

        public Guid? PreviousTaskId { get; set; }
    }
}

