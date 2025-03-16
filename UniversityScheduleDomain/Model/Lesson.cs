using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class Lesson 
    {
        public int LessonId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public int? AuditoriumId { get; set; }
        public int? GroupId { get; set; }
        public string? DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual Auditorium? Auditorium { get; set; } = null!;
        public virtual Course? Course { get; set; } = null!;
        public virtual Group? Group { get; set; } = null!;
        public virtual Teacher? Teacher { get; set; } = null!;
    }
}
