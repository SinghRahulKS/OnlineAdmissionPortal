using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineAdmissionPortal.Models
{
    public class UserModel : BaseModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? EmailConfirmed { get; set; }

    }
}
