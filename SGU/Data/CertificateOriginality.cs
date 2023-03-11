using System;
using System.Collections.Generic;

namespace SGU;

public partial class CertificateOriginality
{
    public long Id { get; set; }

    public string Originality { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
