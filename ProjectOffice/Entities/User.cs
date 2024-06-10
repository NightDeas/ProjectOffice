using System;
using System.Collections.Generic;

namespace ProjectOffice.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public bool IsBanned { get; set; }

    public string? Reason { get; set; }

    public virtual Employee IdNavigation { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
