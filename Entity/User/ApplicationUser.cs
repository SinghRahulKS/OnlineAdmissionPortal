using Microsoft.AspNetCore.Identity;
namespace Entity.User
{
    public class ApplicationUser : IdentityUser
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
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }

    }
}
