using System;
using System.Collections.Generic;

namespace ProjektarbeteSQL.Models
{
    public partial class EmploAdmin
    {
        public int AdminId { get; set; }
        public string Position { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public DateTime? EmploymentDate { get; set; }
        public int? Salary { get; set; }
    }
}
