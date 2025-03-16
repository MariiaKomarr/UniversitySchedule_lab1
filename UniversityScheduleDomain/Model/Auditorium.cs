using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace UniversityScheduleDomain.Model
{
    public partial class Auditorium 
    {
        public Auditorium()
        {
            Lessons = new HashSet<Lesson>();
        }
        public int AuditoriumId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [RegularExpression(@"^Auditorium\s[A-Z0-9]+$", ErrorMessage = "Name must be 'Auditorium' followed by a letter or a number")]
        //[Remote(action: "CheckUniqueName", controller: "Auditoriums", ErrorMessage = "This auditorium already exists")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string? Info { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
