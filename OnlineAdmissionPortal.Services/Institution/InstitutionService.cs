using Dapper;
using DataContext.Repository.Dapper;
using Entity.Common;
using Entity.Institute;
using Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAdmissionPortal.Services.Institution
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IDapperRepository _dapperRepository;
        public InstitutionService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }
        public BoolResponse RegisterInstitute(Institute institute)
        {
            var resp = new BoolResponse();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(new
            {
                @Name = institute.Name,
                @InstituteType = institute.InstituteType,
                @Address = institute.Address,
                @MobileNumber = institute.MobileNumber,
                @WebsiteUrl = institute.WebsiteUrl,
                @Email = institute.Email,
                @EstablishedYear = institute.EstablishedYear,
                @CreatedBy = institute.Created
            });
            resp = _dapperRepository.Insert<BoolResponse>(DBProcedures.procInsertInstitute, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return resp;
        }

        public List<Institute> GetInstituteList(Institute institute)
        {
            var institutess = new List<Institute>();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(new 
            {
                @Name = institute.Name,
                @InstituteType = institute.InstituteType.GetHashCode(),
                @Email = institute.Email,
                @EstablishedYear = institute.EstablishedYear,
            });
            institutess = _dapperRepository.GetAll<Institute>(DBProcedures.procGetAllInstitute, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            return institutess;
        }
    }
}
