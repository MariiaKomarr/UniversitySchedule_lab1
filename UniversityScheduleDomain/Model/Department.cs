using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Department 
    {
        public Department()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; } = null!;
        public string Head { get; set; } = null!;

        public virtual Faculty Faculty { get; set; } = null!;
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
