using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Professors = new HashSet<Professor>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }
    }
}
