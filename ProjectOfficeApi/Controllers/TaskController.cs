
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly Entities.DbContextProjectOffice _context;

        public TaskController()
        {
            _context = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTasks()
        {
            var list = await _context.Tasks
                .Include(x => x.Status)
                .Include(x => x.ExecutiveEmployeed)
                //.Include(x => x.PreviousTask)
            .ToListAsync();
            return Ok(list);
        }

        [HttpGet("Project/{projectId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTasksOfProject(Guid projectId)
        {
            var list = await _context.Tasks
                .Include(x => x.Status)
                .Include(x => x.ExecutiveEmployeed)
                .Include(x => x.PreviousTask)
                .Where(x => x.ProjectId == projectId && x.IsDelete == false)
            .ToListAsync();
            if (list.Count == 0)
                return NotFound();
            return Ok(list);
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var item = await _context.Tasks
                .Include(x => x.ExecutiveEmployeed)
                .Include(x => x.PreviousTask)
                .Include(x=> x.Status)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(TaskRequest request)
        {
            if (request == null)
                return BadRequest();
            Entities.Task task = new(request);
            _context.Tasks.Add(task);
            try
            {
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            TaskResponse response = new TaskResponse(task);
            return Ok(response.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Put(Guid id, TaskRequest request)
        {
            if (request == null)
                return BadRequest();
            Entities.Task task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return NotFound();
            task = new(request);
            try
            {
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            TaskResponse response = new(task);
            return Ok(task);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            Entities.Task task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return NotFound();
            task.IsDelete = true;
            task.DeletedTime = DateTime.UtcNow;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

    }

    public class TaskResponse
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
        public bool IsDelete { get; set; }


        public TaskResponse(Entities.Task task)
        {
            Id = task.Id;
            ProjectId = task.ProjectId;
            FullTitle = task.FullTitle;
            ShortTitle = task.ShortTitle;
            Description = task.Description;
            ExecutiveEmployeedId = task.ExecutiveEmployeedId;
            StatusId = task.StatusId;
            CreatedTime = task.CreatedTime;
            UpdatedTime = task.UpdatedTime;
            DeletedTime = task.DeletedTime;
            Deadline = task.Deadline;
            StartActualTime = task.StartActualTime;
            FinishActualTime = task.FinishActualTime;
            PreviousTaskId = task.PreviousTaskId;
            IsDelete = task.IsDelete;
        }
    }

    public class TaskRequest
    {
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
        public bool IsDelete { get; set; }
    }
}

