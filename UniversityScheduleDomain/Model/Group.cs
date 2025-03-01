using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Group 
    {
        public Group()
        {
            Lessons = new HashSet<Lesson>();
            Students = new HashSet<Student>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; } = null!;
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; } = null!;
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
