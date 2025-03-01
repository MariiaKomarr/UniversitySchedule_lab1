using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Auditorium 
    {
        public Auditorium()
        {
            Lessons = new HashSet<Lesson>();
        }
        public int AuditoriumId { get; set; }
        public string Name { get; set; } = null!;
        public string? Info { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
