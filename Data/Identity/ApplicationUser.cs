using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WSMS.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}