using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Schedule
    {
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Professor Professor { get; set; } = null!;
    }
}
