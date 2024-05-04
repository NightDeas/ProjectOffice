using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOfficeApi.Entities;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        Entities.DbContextProjectOffice context;
        public ProjectController()
        {
            context = new Entities.DbContextProjectOffice();
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var item = await context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();
            ProjectResponse response = new ProjectResponse(item);
            return Ok(item);
        }
    }

    public class ProjectResponse
    {
        public ProjectResponse(Project project)
        {
            Id = project.Id;
            FullTitle = project.FullTitle;
            ShortTitle = project.ShortTitle;
            Icon = project.Icon;
            CreatedTime = project.CreatedTime;
            DeletedTime = project.DeletedTime;
            StartScheduledDate = project.StartScheduledDate;
            FinishScheduledDate = project.FinishScheduledDate;
            Description = project.Description;
            CreatorEmployeedId = project.CreatorEmployeedId;
            ResponsibleEmployeedId = project.ResponsibleEmployeedId;
        }

        public Guid Id { get; set; }

        public string FullTitle { get; set; } = null!;

        public string? ShortTitle { get; set; }

        public string? Icon { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? DeletedTime { get; set; }

        public DateTime? StartScheduledDate { get; set; }

        public DateTime? FinishScheduledDate { get; set; }

        public string? Description { get; set; }

        public Guid? CreatorEmployeedId { get; set; }

        public Guid? ResponsibleEmployeedId { get; set; }
    }
}
