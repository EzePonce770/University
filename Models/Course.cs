using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DepartamentId { get; set; }
        public int Credits { get; set; }

        public virtual Department Departament { get; set; } = null!;
    }
}
