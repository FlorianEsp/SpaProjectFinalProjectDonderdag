using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SpaProjectFinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Event> Event { get; set; }
    }
}
