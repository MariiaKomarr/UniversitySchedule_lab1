using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleDomain.Model
{
    public partial class Department 
    {
        public Department()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int DepartmentId { get; set; }
        public int? FacultyId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Head { get; set; } = null!;

        public virtual Faculty? Faculty { get; set; } = null!;
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
