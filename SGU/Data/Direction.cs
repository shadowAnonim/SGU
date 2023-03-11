using System;
using System.Collections.Generic;

namespace SGU;

public partial class Direction
{
    public long Id { get; set; }

    public long FirstExamId { get; set; }

    public long SecondExamId { get; set; }

    public long ThirdExamId { get; set; }

    public virtual Exam FirstExam { get; set; } = null!;

    public virtual Exam SecondExam { get; set; } = null!;

    public virtual Exam ThirdExam { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
