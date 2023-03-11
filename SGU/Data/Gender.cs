using System;
using System.Collections.Generic;

namespace SGU;

public partial class Gender
{
    public long Id { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
