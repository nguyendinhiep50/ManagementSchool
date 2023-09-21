using Microsoft.AspNetCore.Identity; 

namespace School_version1.Entities
{
    public class CustomIdentityUser : IdentityUser<Guid>
    {
        public virtual Management Management { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }

    }
}
