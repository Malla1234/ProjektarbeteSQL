using System;
using System.Collections.Generic;

namespace ProjektarbeteSQL.Models
{
    public partial class Grade
    {
        public Grade()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int GradeId { get; set; }
        public DateTime? Date { get; set; }
        public string? Subject { get; set; }
        public int? Grade1 { get; set; }
        public int? FkTeacherId { get; set; }
        public int? FkStudId { get; set; }

        public virtual EmploTeacher? FkTeacher { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
