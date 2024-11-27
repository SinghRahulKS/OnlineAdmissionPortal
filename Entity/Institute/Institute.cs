using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Institute
{
    public class Institute : BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int InstituteType { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Email { get; set; }
        public DateOnly EstablishedYear { get; set; }
    }
}
