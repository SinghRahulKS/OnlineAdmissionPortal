using static Entity.Enums.Enum;

namespace OnlineAdmissionPortal.Models
{
    public class AdmissionModel
    {
        public int Id { get; set; }
        public string  StudentName { get; set; }
        public int StudentId { get; set; }
        public string Cource { get; set; }
        public string InstituteName { get; set; }
        public InstituteType InstituteType { get; set; }
    }
}
