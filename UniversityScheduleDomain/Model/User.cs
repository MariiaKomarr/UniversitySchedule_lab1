using System;
using System.Collections.Generic;

namespace UniversityScheduleDomain.Model
{
    public partial class User 
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
