using System;
using System.Collections.Generic;

namespace ProjectOffice.DataBase.Entities;

public partial class Project
{
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

    public virtual ICollection<ProjectsInGroupProject> ProjectsInGroupProjects { get; set; } = new List<ProjectsInGroupProject>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
