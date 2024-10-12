using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public string? RoleId { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? EmailConfirmed { get; set; }
    }
    public enum Role
    {
        User,
        Admin,
        SuperAdmin
    }
}
