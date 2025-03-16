using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10")]
        public int? Credits { get; set; }

        public virtual ICollection<Curriculum> Curricula { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
