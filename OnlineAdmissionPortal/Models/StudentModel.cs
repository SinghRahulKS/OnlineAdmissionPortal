using System.ComponentModel.DataAnnotations;

namespace OnlineAdmissionPortal.Models
{
    public class StudentModel : BaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
