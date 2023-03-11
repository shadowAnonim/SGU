using System;
using System.Collections.Generic;

namespace SGU.Data;

public partial class City
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
