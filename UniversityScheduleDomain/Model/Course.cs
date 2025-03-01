using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Course 
    {
        public Course()
        {
            Curricula = new HashSet<Curriculum>();
            Lessons = new HashSet<Lesson>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; } = null!;
        public int? Credits { get; set; }

        public virtual ICollection<Curriculum> Curricula { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
