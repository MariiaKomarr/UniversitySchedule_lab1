using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Curriculum 
    {
        public int CurriculumId { get; set; }
        public int CourseId { get; set; }
        public int? Semester { get; set; }
        public int? Year { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
