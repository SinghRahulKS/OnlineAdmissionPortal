namespace OnlineAdmissionPortal.Models
{
    public class BaseModel
    {
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }
        public int TotalRecord { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
