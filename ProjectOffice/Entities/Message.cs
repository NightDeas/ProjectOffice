using System;
using System.Collections.Generic;

namespace ProjectOffice.Entities;

public partial class Message
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public Guid EmployeesId { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual ICollection<MessagesInTask> MessagesInTasks { get; set; } = new List<MessagesInTask>();
}
