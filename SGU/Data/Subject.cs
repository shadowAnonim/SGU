using System;
using System.Collections.Generic;

namespace SGU.Data;

public partial class Subject
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();
}
