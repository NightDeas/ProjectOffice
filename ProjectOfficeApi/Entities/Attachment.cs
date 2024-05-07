using System;
using System.Collections.Generic;

namespace ProjectOfficeApi.Entities;

public partial class Attachment
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public string? NamePhoto { get; set; }

    public byte[]? Photo { get; set; }

    public double? SizeFile { get; set; }

    public virtual ICollection<AttachmentsInTask> AttachmentsInTasks { get; set; } = new List<AttachmentsInTask>();
}
