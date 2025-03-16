using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleDomain.Model
{
    public partial class Curriculum 
    {
        public int CurriculumId { get; set; }
        public int? CourseId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8")]
        public int? Semester { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Range(2000, 2100, ErrorMessage = "Year must be between 2000 and 2100")]
        public int Year { get; set; }

        public virtual Course? Course { get; set; } = null!;
    }
}
