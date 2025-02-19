namespace OnlineAdmissionPortal.Models
{
    public class InstituteModel
    {
        public long Id { get; set; }                        
        public string? Name { get; set; }                 
        public int InstituteType { get; set; }            
        public string? Address { get; set; }               
        public string? MobileNumber { get; set; }        
        public string? WebsiteUrl { get; set; }                 
        public string? Email { get; set; }
        public DateTime EstablishedYear { get; set; }
    }

}
