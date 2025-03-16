using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleDomain.Model
{
    public partial class Teacher 
    {
        public Teacher()
        {
            Lessons = new HashSet<Lesson>();
            Users = new HashSet<User>();
        }

        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string FullName { get; set; } = null!;
        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid phone number format(e.g., +1234567890)")]
        public string? Phone { get; set; }

        //public virtual Department Department { get; set; } = null!;
        public virtual Department? Department { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
