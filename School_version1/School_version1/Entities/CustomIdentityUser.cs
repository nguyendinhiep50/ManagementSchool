using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace School_version1.Entities
{
    public class CustomIdentityUser : IdentityUser
    {
        public virtual Management Management { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }

    }
}
