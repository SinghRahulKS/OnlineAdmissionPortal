using Entity.Common;
using Entity.Institute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAdmissionPortal.Services.Institution
{
    public interface IInstitutionService
    {
        BoolResponse RegisterInstitute(Institute institute);
        List<Institute> GetInstituteList(Institute institute);
    }
}
