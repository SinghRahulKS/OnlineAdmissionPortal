using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.Enums.Enum;

namespace Entity.Institute
{
    public class Institute : BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public InstituteType InstituteType { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Email { get; set; }
        public DateTime EstablishedYear
        {
            get => _establishedYear == DateTime.MinValue ? new DateTime(1753, 1, 1) : _establishedYear;
            set => _establishedYear = value;
        }
        private DateTime _establishedYear;

    }
}
