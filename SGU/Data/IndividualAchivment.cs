using System;
using System.Collections.Generic;

namespace SGU.Data;

public partial class IndividualAchivment
{
    public long UserId { get; set; }

    public byte[] Scan { get; set; } = null!;

    public long Id { get; set; }

    public virtual User User { get; set; } = null!;
}
