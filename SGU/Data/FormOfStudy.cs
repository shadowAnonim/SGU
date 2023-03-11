using System;
using System.Collections.Generic;

namespace SGU;

public partial class FormOfStudy
{
    public long Id { get; set; }

    public string From { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
