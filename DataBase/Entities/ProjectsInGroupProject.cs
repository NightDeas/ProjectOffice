using System;
using System.Collections.Generic;

namespace ProjectOffice.DataBase.Entities;

public partial class ProjectsInGroupProject
{
    public int Id { get; set; }

    public int GroupProjectId { get; set; }

    public Guid ProjectId { get; set; }

    public virtual GroupProject GroupProject { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
