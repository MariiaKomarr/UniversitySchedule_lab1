using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Teacher 
    {
        public Teacher()
        {
            Lessons = new HashSet<Lesson>();
            Users = new HashSet<User>();
        }

        public int TeacherId { get; set; }
        public string FullName { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
