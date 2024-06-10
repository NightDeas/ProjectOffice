using System;
using System.Collections.Generic;

namespace ProjectOffice.Entities;

public partial class GroupProject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<ProjectsInGroupProject> ProjectsInGroupProjects { get; set; } = new List<ProjectsInGroupProject>();
}
