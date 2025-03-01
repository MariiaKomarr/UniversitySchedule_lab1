using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleDomain.Model
{
    public partial class Faculty 
    {
        public Faculty()
        {
            Departments = new HashSet<Department>();
            Groups = new HashSet<Group>();
        }

        public int FacultyId { get; set; }
        [Required(ErrorMessage ="Поле не може бути порожнім")]
        [Display(Name="Факультет")]
        public string Name { get; set; } = null!;

        [Display(Name="Декан")]
        public string Dean { get; set; } = null!;

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
