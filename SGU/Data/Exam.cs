using System;
using System.Collections.Generic;

namespace SGU;

public partial class Exam
{
    public long Id { get; set; }

    public long SubjectId { get; set; }

    public long Scores { get; set; }

    public virtual ICollection<Direction> DirectionFirstExams { get; } = new List<Direction>();

    public virtual ICollection<Direction> DirectionSecondExams { get; } = new List<Direction>();

    public virtual ICollection<Direction> DirectionThirdExams { get; } = new List<Direction>();

    public virtual Subject Subject { get; set; } = null!;
}
