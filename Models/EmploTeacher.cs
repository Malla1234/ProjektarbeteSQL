using System;
using System.Collections.Generic;

namespace ProjektarbeteSQL.Models
{
    public partial class EmploTeacher
    {
        public EmploTeacher()
        {
            Grades = new HashSet<Grade>();
        }

        public int TeacherId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string? Subject { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public int? Salary { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
