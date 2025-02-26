using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.Enums.Enum;

namespace Entity.Admission
{
    public class Admission
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public string Cource { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string InstituteName { get; set; }
        public InstituteType InstituteType { get; set; }
    }
}
