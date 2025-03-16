using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleDomain.Model
{
    public partial class User 
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [MinLength(11, ErrorMessage = "Пароль має бути не менше 11 символів")]
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
