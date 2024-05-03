using System;
using System.Collections.Generic;

namespace ProjectOfficeApi.Entities;

public partial class TaskStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ColorHex { get; set; } = null!;

    public int? Type { get; set; }

    public virtual ICollection<HistoryChangeStatus> HistoryChangeStatuses { get; set; } = new List<HistoryChangeStatus>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
