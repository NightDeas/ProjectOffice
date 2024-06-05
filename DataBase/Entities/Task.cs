using System;
using System.Collections.Generic;

namespace ProjectOffice.DataBase.Entities;

public partial class Task
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public string FullTitle { get; set; } = null!;

    public string ShortTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid ExecutiveEmployeedId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeletedTime { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? StartActualTime { get; set; }

    public DateTime? FinishActualTime { get; set; }

    public Guid? PreviousTaskId { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<AttachmentsInTask> AttachmentsInTasks { get; set; } = new List<AttachmentsInTask>();

    public virtual Employee ExecutiveEmployeed { get; set; } = null!;

    public virtual ICollection<HistoryChangeStatus> HistoryChangeStatuses { get; set; } = new List<HistoryChangeStatus>();

    public virtual ICollection<Task> InversePreviousTask { get; set; } = new List<Task>();

    public virtual ICollection<MessagesInTask> MessagesInTasks { get; set; } = new List<MessagesInTask>();

    public virtual Task? PreviousTask { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual ICollection<TaskObserveEmployee> TaskObserveEmployees { get; set; } = new List<TaskObserveEmployee>();
}
