using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Common
{

    public class OnlineAdmissionPortalConstants
    {
        public const string DB_OnlineAdmissionPortal = "OnlineAdmissionConnectionString";
    }
    public class DBProcedures
    {
        public const string procGetAspNetUsers = "procGetAspNetUsers";
        public const string procDeleteUser = "procDeleteUser";
        public const string procUpdateUserInfo = "procUpdateUserInfo";
        public const string procGetUserDetail = "procGetUserDetail";
        public const string procGetAllStudents = "procGetStudents";
        public const string procInsertStudentInfo = "procInsertStudent_20250216";
        public const string procGetAllInstitute = "procGetAllInstitutes";
        public const string procInsertInstitute = "procInsertInstitute";
        public const string procInsertAdmission = "InsertAdmission";
        public const string procGetAllAdmissions = "GetAllAdmissions";
    }
}
