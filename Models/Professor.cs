using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DepartmentDepartmentId { get; set; }
        public int Salary { get; set; }

        public virtual Department? DepartmentDepartment { get; set; }
    }
}
