using System;
using System.Collections.Generic;

namespace ProjektarbeteSQL.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int StudId { get; set; }
        public string Ssn { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int? FkClassId { get; set; }
        public string? Class { get; set; }

        public virtual Class? FkClass { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
