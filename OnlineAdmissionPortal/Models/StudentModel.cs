namespace OnlineAdmissionPortal.Models
{
    public class StudentModel : BaseModel
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}
