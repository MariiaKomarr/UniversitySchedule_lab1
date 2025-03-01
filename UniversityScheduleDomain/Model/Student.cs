using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Student 
    {
        public Student()
        {
            Users = new HashSet<User>();
        }

        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public int GroupId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
