using Dapper;
using DataContext.Repository.Dapper;
using Entity.Common;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAdmissionPortal.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IDapperRepository _dapperRepository;
        public AccountService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository; 
        }

        public ApplicationUser GetUserDetail(Guid id)
        {
            var user = new ApplicationUser();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(
            new
            {
                @Id = id
            });
            var dbResponse = _dapperRepository.Get<ApplicationUser>(DBProcedures.procGetUserDetail, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            if (dbResponse != null)
            {
                user = dbResponse;
            }
            return user;
        }
        public BoolResponse DeleteUser(string id)
        {
            var resp = new BoolResponse(); 
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(
            new
            {
                    @Id = id
            });
            var dbResponse = _dapperRepository.Update<BoolResponse>(DBProcedures.procDeleteUser, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            if (dbResponse != null)
            {
                resp.RecordId = dbResponse.RecordId;
                resp.IsValid = dbResponse.IsValid;
                resp.Message = dbResponse.Message;
            }
            return resp;
        }

        public List<ApplicationUser> GetUsers(ApplicationUser user)
        {
            var users = new List<ApplicationUser>();
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.AddDynamicParams(new
            {
                @FirstName = user.FirstName,
                @LastName = user.LastName,
                @UserName = user.UserName,
                @RoleName = user.RoleName,
                @CurrentPage = user.CurrentPage,
                @PageSize = user.PageSize
            });
            var dbResponse = _dapperRepository.GetAll<ApplicationUser>(DBProcedures.procGetAspNetUsers, dbParams, OnlineAdmissionPortalConstants.DB_OnlineAdmissionPortal);
            if (dbResponse != null)
            {
                users = dbResponse;
            }
            return users;

        }
    }
}
