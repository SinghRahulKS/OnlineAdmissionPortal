using System;
using Microsoft.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entity.User
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserName { get; set; }
        public string?  Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RoleName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }

    }
}
